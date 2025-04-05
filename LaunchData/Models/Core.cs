using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Core
    {
        [JsonPropertyName("core")]
        public string CoreId { get; set; }

        public int? Flight { get; set; }
        public bool? Gridfins { get; set; }
        public bool? Legs { get; set; }
        public bool? Reused { get; set; }

        [JsonPropertyName("landing_attempt")]
        public bool? LandingAttempt { get; set; }

        [JsonPropertyName("landing_success")]
        public bool? LandingSuccess { get; set; }

        [JsonPropertyName("landing_type")]
        public string LandingType { get; set; }

        public string Landpad { get; set; }

    }
}
