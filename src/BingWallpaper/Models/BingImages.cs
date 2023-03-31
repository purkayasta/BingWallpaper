using System.Text.Json.Serialization;

namespace BingWallpaper.Models
{
	public class BingImageInfo
	{
		[JsonPropertyName("startdate")]
		public int StartDate { get; set; }

		[JsonPropertyName("fullstartdate")]
		public Int64 FullStartDate { get; set; }

		[JsonPropertyName("enddate")]
		public int EndDate { get; set; }

		[JsonPropertyName("url")]
		public string? Url { get; set; }

		[JsonPropertyName("urlbase")]
		public string? UrlBase { get; set; }

		[JsonPropertyName("copyright")]
		public string? CopyRight { get; set; }

		[JsonPropertyName("copyrightlink")]
		public string? CopyRightLink { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("quiz")]
		public string? Quiz { get; set; }

		[JsonPropertyName("hsh")]
		public string? Hash { get; set; }
	}
}
