using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
