using System.Text;

namespace BingWallpaper.Shared
{
    internal class Utils
    {
        /// <summary>
        /// INDEX
        /// </summary>
        internal static string INDEX_STR = "INDEX";

        /// <summary>
        /// COUNT
        /// </summary>
        internal static string COUNT_STR = "COUNT";

        /// <summary>
        /// LOCALE
        /// </summary>
        internal static string LOCALE_STR = "LOCALE";

        /// <summary>
        /// http://www.bing.com
        /// </summary>
        internal static string BaseUrl = "https://www.bing.com";

        /// <summary>
        /// HPImageArchive.aspx
        /// </summary>
        internal static string ImageArchiveUrl = "HPImageArchive.aspx?format=js&idx=INDEX&n=COUNT&mkt=LOCALE";
        internal static string BingWallUrl => BaseUrl + "/" + ImageArchiveUrl;

        /// <summary>
        /// Bing
        /// </summary>
        internal const string FolderPrefix = "Bing";

        /// <summary>
        /// 2
        /// </summary>
        internal static int TotalWeek = 2;

        /// <summary>
        /// 8
        /// </summary>
        internal static int PerWeekDownloadableData = 8;

        /// <summary>
        /// 15
        /// </summary>
        internal static int TotalDownloadableData = 15;

        internal static string GetProperBingUrl(int index, int download, string? locale)
        {
            return BingWallUrl
                .Replace(INDEX_STR, index.ToString())
                .Replace(COUNT_STR, download.ToString())
                .Replace(LOCALE_STR, locale);
        }
        /// <summary>
        /// It will return remaining count like
        /// total => 33, count => 8
        /// 33 - (8*1) = remaining = 25
        /// 33 - (8*2) = remaining = 17
        /// </summary>
        /// <param name="totalCount">Total Count</param>
        /// <param name="maxPerPageCount">Max Per Page</param>
        /// <param name="page">Currently selected page</param>
        /// <returns></returns>
        internal static int GetRemaining(int totalCount, int maxPerPageCount, int page)
            => totalCount - maxPerPageCount * page;

        internal static string RemoveSpecialCharacters(string? str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str.Length < 1)
                return string.Empty;

            StringBuilder sb = new();
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9' || c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        internal static string[] PrepareUrls(int downloadRequest, string? locale)
        {
            string[] urlArray = new string[TotalWeek];

            if (downloadRequest <= PerWeekDownloadableData)
            {
                urlArray[0] = GetProperBingUrl(
                    index: 0,
                    download: downloadRequest,
                    locale: locale);

                return urlArray;
            }
            else
            {
                urlArray[0] = GetProperBingUrl(
                    index: 0,
                    download: PerWeekDownloadableData,
                    locale: locale);

                urlArray[1] = GetProperBingUrl(
                    index: PerWeekDownloadableData + 1,
                    download: downloadRequest - PerWeekDownloadableData,
                    locale: locale);

                return urlArray;
            }
        }
    }
}
