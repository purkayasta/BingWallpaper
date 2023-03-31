﻿using BingWallpaper.Contracts;
using BingWallpaper.Core;
using BingWallpaper.Models;
using BingWallpaper.Shared;

namespace BingWallpaper.Implementation
{
    internal class BingWallpaperService : IBingWallpaperService
    {
        private readonly ICustomHttpClient _customHttpClient;

        public BingWallpaperService(ICustomHttpClient customHttpClient)
            => _customHttpClient = customHttpClient;

        public async Task<List<BingImageInfo>> GetDailyWallpaperInfoAsync(int downloadRequest, string locale = "en-US")
        {
            if (downloadRequest < 1)
                throw new Exception(message: "Download Count cannot be less than 1");

            if (string.IsNullOrEmpty(locale) || string.IsNullOrWhiteSpace(locale))
                throw new Exception(message: "locale cannot be empty");

            if (downloadRequest > Utils.TotalDownloadableData)
                throw new Exception(message: $"Cannot download more than {Utils.TotalDownloadableData}");

            var urls = Utils.PrepareUrls(downloadRequest, locale);

            var bingImages = new List<BingImageInfo>();

            foreach (var url in urls)
            {
                var wallpaperSource = await _customHttpClient.GetFromJsonAsync<BingWall>(url);

                if (wallpaperSource is not null && wallpaperSource.BingImages is not null && wallpaperSource.BingImages.Any())
                    bingImages.AddRange(wallpaperSource.BingImages);
            }

            return bingImages;
        }

        public async Task DownloadAsync(string imageUrl, string imageName, string imageExtension, string localDownloadPath, string folderPrefix = Utils.FolderPrefix)
        {
            var directoryInfo = Directory.CreateDirectory(localDownloadPath + "/" + folderPrefix);
            using var stream = await _customHttpClient.GetStreamAsync(Utils.BaseUrl + imageUrl);
            string imageFilePath = directoryInfo.FullName + "/" + Utils.RemoveSpecialCharacters(imageName.Trim()) + "." + imageExtension;
            using var fileStream = File.Create(imageFilePath);
            await stream.CopyToAsync(fileStream);
            await Console.Out.WriteLineAsync($"File Downloaded at {imageFilePath}");
        }
    }
}
