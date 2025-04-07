using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Patch
    {
        [Key]
        public int? Id { get; set; }

        [JsonPropertyName("small")]
        public string? Small { get; set; }

        [JsonPropertyName("large")]
        public string? Large { get; set; }
    }
}
