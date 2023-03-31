using BingWallpaper.Contracts;
using BingWallpaper.Core;
using BingWallpaper.Implementation;

namespace BingWallpaper.Installer
{
	public static class BingWallpaperInstaller
	{
		public static IBingWallpaperService CreateService()
		{
			var socketHandler = new SocketsHttpHandler();
			return new BingWallpaperService(new CustomHttpClient(new HttpClient(socketHandler)));
		}
	}
}
