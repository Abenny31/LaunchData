using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Flickr
    {
        [Key]
        public int? Id { get; set; }

        [JsonPropertyName("small")]
        public List<string>? Small { get; set; } = new();

        [JsonPropertyName("original")]
        public List<string>? Original { get; set; } = new();
    }
}
