using BingWallpaper.Contracts;
using BingWallpaper.Core;
using BingWallpaper.Implementation;

namespace BingWallpaper.Installer
{
    public static class BingWallpaperInstaller
    {
        /// <summary>
        /// Get a IBingWallpaperService instance to use this API.
        /// </summary>
        public static IBingWallpaperService? CreateService()
        {
            var socketHandler = new SocketsHttpHandler();
            return new BingWallpaperService(new CustomHttpClient(new HttpClient(socketHandler)));
        }
    }
}
