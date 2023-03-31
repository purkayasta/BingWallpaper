using System.Text.Json.Serialization;

namespace BingWallpaper.Models
{
	public class BingWall
	{
		[JsonPropertyName("images")]
		public List<BingImageInfo>? BingImages { get; set; }
	}
}
