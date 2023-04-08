# Bing Wallpaper API

## Give it a star on [github](https://github.com/purkayasta/BingWallpaper) if you like the project. 👏 🌠 🌟

BingWallpaper API is for you to download bing daily wallpaper at ease.

## Invoke:
To Use this library your friend will be this interface ```IBingWallpaperService```.

## instantiation
Two ways of getting the instance
- Factory:
```BingWallpaperService.CreateService()```

OR
- Service Collection Extension
```services.AddBingWallpaper()```

## Usage:

### Console APP:
```c#
var bingWallpaper = BingWallpaperInstaller.CreateService();
var source = bingWallpaper.GetDailyWallpaperInfo(15);

foreach (var imageUrl in source)
{
	Console.WriteLine($"Title: {imageUrl.Title}");
	bingWallpaper.Download(imageUrl.Url!, imageUrl.Title!.Trim(), "png", "D://");
}
```

### Web App / API
```c#
public Controller {
	private readonly IBingWallpaperService _service;

	Controller(IBingWallpaperService service) => _service = service;

	[HttpGet()]
	public async Task<IActionResult> GetWallpaperSource(int count){
		var source = await bingWallpaper.GetDailyWallpaperInfoAsync(count);
		return OK(source);
	}

}
```




Made ❤ with C#.