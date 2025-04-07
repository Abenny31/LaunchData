using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Rocket
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }


    }
}
