using System.Text.Json.Serialization;

namespace BingWallpaper.Models
{
    public sealed class BingWall
    {
        [JsonPropertyName("images")]
        public List<BingImageInfo>? BingImages { get; set; }
    }
}
