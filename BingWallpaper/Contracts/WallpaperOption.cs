using System.ComponentModel.DataAnnotations;

namespace BingWallpaper.Contracts
{
    public class WallpaperOption
    {
        [MaxLength(20)]
        public int DownloadCount { get; set; }
        public ResolutionType Resolution { get; set; }
    }
    public enum ResolutionType
    {

    }
}
