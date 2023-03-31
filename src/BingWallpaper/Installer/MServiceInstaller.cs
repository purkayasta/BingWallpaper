using BingWallpaper.Contracts;
using BingWallpaper.Core;
using BingWallpaper.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BingWallpaper.Installer
{
    public static class MServiceInstaller
	{
		public static void AddBingWallpaper(this IServiceCollection services)
		{
			services.AddHttpClient();
			services.AddSingleton<ICustomHttpClient, CustomHttpClient>();
			services.AddScoped<IBingWallpaperService, BingWallpaperService>();
		}
	}
}
