using System.Text.Json.Serialization;

namespace BingWallpaper.Models
{
    public sealed class BingImageInfo
    {
        /// <summary>
        /// Image Start Date.
        /// </summary>
        [JsonPropertyName("startdate")]
        public int StartDate { get; set; }

        /// <summary>
        /// Image Full Start Date.
        /// </summary>
        [JsonPropertyName("fullstartdate")]
        public Int64 FullStartDate { get; set; }

        /// <summary>
        /// Image End Date.
        /// </summary>
        [JsonPropertyName("enddate")]
        public int EndDate { get; set; }

        /// <summary>
        /// Image URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Image URL Base.
        /// </summary>
        [JsonPropertyName("urlbase")]
        public string? UrlBase { get; set; }

        /// <summary>
        /// Image Copyright.
        /// </summary>
        [JsonPropertyName("copyright")]
        public string? CopyRight { get; set; }

        /// <summary>
        /// Copyright link.
        /// </summary>
        [JsonPropertyName("copyrightlink")]
        public string? CopyRightLink { get; set; }

        /// <summary>
        /// Name of this image.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("quiz")]
        public string? Quiz { get; set; }

        /// <summary>
        /// Hash of this image.
        /// </summary>
        [JsonPropertyName("hsh")]
        public string? Hash { get; set; }
    }
}
