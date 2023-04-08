using BingWallpaper.Contracts;
using BingWallpaper.Core;
using BingWallpaper.Models;
using BingWallpaper.Shared;

namespace BingWallpaper.Implementation
{
    internal sealed class BingWallpaperService : IBingWallpaperService
    {
        private readonly ICustomHttpClient _customHttpClient;

        public BingWallpaperService(ICustomHttpClient customHttpClient)
            => _customHttpClient = customHttpClient;

        #region GetDailyWallpaperSourceInfo

        public async Task<List<BingImageInfo?>> GetDailyWallpaperInfoAsync(int downloadRequest, string? locale = "en-US")
        {
            ValidateWallpaperSource(downloadRequest, locale);

            var urls = Utils.PrepareUrls(downloadRequest, locale);

            var bingImages = Enumerable.Empty<BingImageInfo?>().ToList();

            foreach (var url in urls)
            {
                var wallpaperSource = await _customHttpClient.GetFromJsonAsync<BingWall>(url);

                if (wallpaperSource is not null && wallpaperSource.BingImages is not null && wallpaperSource.BingImages.Any())
                    bingImages.AddRange(wallpaperSource.BingImages);
            }

            return bingImages;
        }
        public List<BingImageInfo?> GetDailyWallpaperInfo(int downloadRequest, string? locale = "en-US")
        {
            ValidateWallpaperSource(downloadRequest, locale);

            var urls = Utils.PrepareUrls(downloadRequest, locale);

            var bingImages = Enumerable.Empty<BingImageInfo?>().ToList();

            foreach (var url in urls)
            {
                var wallpaperSource = _customHttpClient.GetFromJsonAsync<BingWall>(url).GetAwaiter().GetResult();

                if (wallpaperSource is not null && wallpaperSource.BingImages is not null && wallpaperSource.BingImages.Any())
                    bingImages.AddRange(wallpaperSource.BingImages);
            }

            return bingImages;

        }
        private static void ValidateWallpaperSource(int downloadRequest, string? locale)
        {
            if (downloadRequest < 1)
                throw new Exception(message: "Download Count cannot be less than 1");

            if (string.IsNullOrEmpty(locale) || string.IsNullOrWhiteSpace(locale))
                throw new Exception(message: "locale cannot be empty");

            if (downloadRequest > Utils.TotalDownloadableData)
                throw new Exception(message: $"Cannot download more than {Utils.TotalDownloadableData}");
        }

        #endregion

        #region Download

        public async Task<bool> DownloadAsync(string? imageUrl, string? imageName, string? imageExtension, string? localDownloadPath, string? folderPrefix = Utils.FolderPrefix)
        {
            try
            {
                ValidateDownload(imageUrl, imageName, imageExtension, localDownloadPath, folderPrefix);

                var directoryInfo = Directory.CreateDirectory(localDownloadPath + "/" + folderPrefix);
                string imageFilePath = directoryInfo.FullName + "/" + Utils.RemoveSpecialCharacters(imageName?.Trim()) + "." + imageExtension;

                using var stream = await _customHttpClient.GetStreamAsync(Utils.BaseUrl + imageUrl);
                using var fileStream = File.Create(imageFilePath);
                await stream.CopyToAsync(fileStream);

                await Console.Out.WriteLineAsync($"File Downloaded at {imageFilePath}");
                return true;
            }
            catch (Exception downloadException)
            {
                Console.WriteLine(downloadException.Message);
                return false;
            }
        }
        public bool Download(string? imageUrl, string? imageName, string? imageExtension, string? localDownloadPath, string? folderPrefix = "Bing/")
        {
            try
            {
                ValidateDownload(imageUrl, imageName, imageExtension, localDownloadPath, folderPrefix);

                var directoryInfo = Directory.CreateDirectory(localDownloadPath + "/" + folderPrefix);
                string imageFilePath = directoryInfo.FullName + "/" + Utils.RemoveSpecialCharacters(imageName?.Trim()) + "." + imageExtension;

                using var stream = _customHttpClient.GetStreamAsync(Utils.BaseUrl + imageUrl).GetAwaiter().GetResult();
                using var fileStream = File.Create(imageFilePath);
                stream.CopyTo(fileStream);

                Console.WriteLine($"File Downloaded at {imageFilePath}");
                return true;
            }
            catch (Exception downloadException)
            {
                Console.WriteLine(downloadException.Message);
                return false;
            }
        }
        private static void ValidateDownload(string? imageUrl, string? imageName, string? imageExtension, string? localDownloadPath, string? folderPrefix)
        {
            if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrWhiteSpace(imageUrl))
                throw new Exception(nameof(imageUrl) + " is empty");

            if (string.IsNullOrEmpty(imageName) || string.IsNullOrWhiteSpace(imageName))
                throw new Exception(nameof(imageName) + " is empty");

            if (string.IsNullOrEmpty(imageExtension) || string.IsNullOrWhiteSpace(imageExtension))
                throw new Exception(nameof(imageExtension) + " is empty");

            if (string.IsNullOrEmpty(localDownloadPath) || string.IsNullOrWhiteSpace(localDownloadPath))
                throw new Exception(nameof(localDownloadPath) + " is empty");

            if (string.IsNullOrEmpty(folderPrefix) || string.IsNullOrWhiteSpace(folderPrefix))
                throw new Exception(nameof(folderPrefix) + " is empty");
        }

        #endregion
    }
}
