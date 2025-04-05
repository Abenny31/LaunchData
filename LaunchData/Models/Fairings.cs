using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Fairings
    {

        public int Id { get; set; }
        public bool? Reused { get; set; }

        [JsonPropertyName("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        public bool? Recovered { get; set; }
        public List<string> Ships { get; set; }
    }
}
