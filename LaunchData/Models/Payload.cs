using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Payload
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("mass_kg")]
        public double? MassKg { get; set; }

        [JsonPropertyName("orbit")]
        public string? Orbit { get; set; }
    }
}
