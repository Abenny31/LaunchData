using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class LaunchPad
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }
}
