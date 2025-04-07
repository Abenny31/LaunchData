using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Reddit
    {
        [Key]
        public int? Id { get; set; }

        [JsonPropertyName("campaign")]
        public string? Campaign { get; set; }

        [JsonPropertyName("launch")]
        public string? Launch { get; set; }

        [JsonPropertyName("media")]
        public string? Media { get; set; }

        [JsonPropertyName("recovery")]
        public string? Recovery { get; set; }
    }
}
