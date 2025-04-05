using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class Links
    {

        public int Id { get; set; }
        public Patch Patch { get; set; }
        public Reddit Reddit { get; set; }
        public Flickr Flickr { get; set; }
        public string Presskit { get; set; }
        public string Webcast { get; set; }

        [JsonPropertyName("youtube_id")]
        public string YoutubeId { get; set; }

        public string Article { get; set; }
        public string Wikipedia { get; set; }
    }
}
