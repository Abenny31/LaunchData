using System.ComponentModel.DataAnnotations;

namespace LaunchData.Models
{
    public class CrewMember
    {
        [Key]
        public int? Id { get; set; }
        public string? Crew { get; set; }
        public string? Role { get; set; }
    }
}
