using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Failure
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("time")]
        public int? Time { get; set; }

        [JsonPropertyName("altitude")]
        public int? Altitude { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [ForeignKey("Launch")]
        public string? LaunchId { get; set; }
    }

}
