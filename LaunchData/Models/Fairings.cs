using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Fairings
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("reused")]
        public bool? Reused { get; set; }

        [JsonPropertyName("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        [JsonPropertyName("recovered")]
        public bool? Recovered { get; set; }

        [JsonPropertyName("ships")]
        public List<string> Ships { get; set; } = new();
    }
}
