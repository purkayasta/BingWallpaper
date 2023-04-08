using BingWallpaper.Installer;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Fetching Wallpaper 🌟");

var bingWallpaper = BingWallpaperInstaller.CreateService();
var source = await bingWallpaper!.GetDailyWallpaperInfoAsync(15);

if (source == null || !source.Any())
{
    Console.WriteLine("Nothing found from bing ⚠");
    return;
}

foreach (var imageUrl in source)
{
    Console.WriteLine($"Title: {imageUrl!.Title} ✅");
    Console.WriteLine($"Quiz: {imageUrl.Quiz}");
    Console.WriteLine($"Copyright: {imageUrl.CopyRight}");
    Console.WriteLine($"Link: {imageUrl.CopyRightLink}");
    Console.WriteLine("\n");
    var result = await bingWallpaper.DownloadAsync(imageUrl.Url!, imageUrl.Title!.Trim(), "png", "D://");
    if (result == false) Console.WriteLine("Download failed ⚡");
}

Console.WriteLine("Ending");