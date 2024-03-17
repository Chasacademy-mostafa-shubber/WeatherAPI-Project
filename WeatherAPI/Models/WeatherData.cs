using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherData
    {   
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }
}
