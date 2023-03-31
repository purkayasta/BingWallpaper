// See https://aka.ms/new-console-template for more information
using BingWallpaper.Installer;

Console.WriteLine("Starting");

var bingWallpaper = BingWallpaperInstaller.CreateService();
var source = await bingWallpaper.GetDailyWallpaperInfoAsync(15);

foreach (var imageUrl in source)
{
	Console.WriteLine($"Title: {imageUrl.Title}");
	await bingWallpaper.DownloadAsync(imageUrl.Url!, imageUrl.Title!.Trim(), "png", "D://");
}

Console.WriteLine("Ending");