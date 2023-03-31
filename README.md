# Bing Wallpaper

## Give it a star if you like the project. 👏 🌠 🌟

BingWallpaper API is for you to download bing daily wallpaper at ease.

![Nuget](https://img.shields.io/nuget/v/BingWallpaper)
![Nuget](https://img.shields.io/nuget/dt/BingWallpaper?style=plastic)
![Nuget](https://img.shields.io/github/repo-size/purkayasta/BingWallpaper?style=social)
![Nuget](https://img.shields.io/github/last-commit/purkayasta/BingWallpaper?style=flat-square)

Download from [Nuget](https://www.nuget.org/packages/BingWallpaper/)

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
var source = await bingWallpaper.GetDailyWallpaperInfoAsync(15);

foreach (var imageUrl in source)
{
	Console.WriteLine($"Title: {imageUrl.Title}");
	await bingWallpaper.DownloadAsync(imageUrl.Url!, imageUrl.Title!.Trim(), "png", "D://");
}
```




Made ❤ with C#.