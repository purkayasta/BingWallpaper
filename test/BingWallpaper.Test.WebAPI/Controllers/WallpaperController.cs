using BingWallpaper.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BingWallpaper.Test.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WallpaperController : ControllerBase
    {
        private readonly IBingWallpaperService _service;
        private readonly ILogger<WallpaperController> _logger;

        public WallpaperController(ILogger<WallpaperController> logger, IBingWallpaperService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetBingWallpaper")]
        public async Task<IActionResult> Get(int downloadCount)
        {
            _logger.LogInformation("Fetching bing wallpaper information");
            var result = await _service.GetDailyWallpaperInfoAsync(downloadCount);

            if (result.Any())
            {
                _logger.LogDebug($"Wallpaper found: {result.Count}");
                return Ok(result);
            }

            _logger.LogError("No Wallpaper found");
            return NotFound();
        }
    }
}