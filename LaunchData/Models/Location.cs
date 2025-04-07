using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Location
    {
        [Key]
        public int? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }
    }
}
