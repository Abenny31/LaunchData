using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Core
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("core")]
        public string? CoreId { get; set; }

        [JsonPropertyName("flight")]
        public int? Flight { get; set; }

        [JsonPropertyName("gridfins")]
        public bool? Gridfins { get; set; }

        [JsonPropertyName("legs")]
        public bool? Legs { get; set; }

        [JsonPropertyName("reused")]
        public bool? Reused { get; set; }

        [JsonPropertyName("landing_attempt")]
        public bool? LandingAttempt { get; set; }

        [JsonPropertyName("landing_success")]
        public bool? LandingSuccess { get; set; }

        [JsonPropertyName("landing_type")]
        public string? LandingType { get; set; }

        [JsonPropertyName("landpad")]
        public string? Landpad { get; set; }

        [ForeignKey("Launch")]
        public string? LaunchId { get; set; }


    }
}
