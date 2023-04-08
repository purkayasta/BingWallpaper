using BingWallpaper.Models;

namespace BingWallpaper.Contracts
{
    public interface IBingWallpaperService
    {
        /// <summary>
        /// (async) This method will download the wallpaper at given path.
        /// </summary>
        /// <param name="imageUrl">Raw Image URL</param>
        /// <param name="imageName">Image Name without any space</param>
        /// <param name="imageExtension">just the extension, do not give any specifier like (.)</param>
        /// <param name="localDownloadPath">The local storage physical path address</param>
        /// <param name="folderPrefix">ByDefault it is set with Bing, Unless you have something in your mind 😜.</param>
        /// <returns></returns>
        Task<bool> DownloadAsync(string imageUrl, string imageName, string imageExtension, string localDownloadPath, string folderPrefix = "Bing/");

        /// <summary>
        /// This method will download the wallpaper at given path.
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="imageName"></param>
        /// <param name="imageExtension"></param>
        /// <param name="localDownloadPath"></param>
        /// <param name="folderPrefix"></param>
        /// <returns></returns>
        bool Download(string imageUrl, string imageName, string imageExtension, string localDownloadPath, string folderPrefix = "Bing/");


        /// <summary>
        /// (async) This method will return all the information related to the daily bing wallpaper, so that one may download it.
        /// </summary>
        /// <param name="downloadRequest">How many wallpapers you want to download? BTW You can only download 2 weeks of daily wallpaper (15)</param>
        /// <param name="locale">Default Locale is en-US</param>
        /// <returns></returns>
        Task<List<BingImageInfo?>> GetDailyWallpaperInfoAsync(int downloadRequest, string? locale = "en-US");

        /// <summary>
        /// This method will return all the information related to the daily bing wallpaper, so that one may download it.
        /// </summary>
        /// <param name="downloadRequest"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        List<BingImageInfo?> GetDailyWallpaperInfo(int downloadRequest, string? locale = "en-US");
    }
}