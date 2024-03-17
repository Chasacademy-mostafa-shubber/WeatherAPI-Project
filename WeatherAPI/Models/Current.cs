using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class Current
    {
        [JsonPropertyName("temp_c")]
        public decimal TempC { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TempF { get; set; }

        [JsonPropertyName("humidity")]
        public decimal Humidity { get; set; }

        [JsonPropertyName("wind_mph")]
        public decimal WindMPH { get; set; }

        [JsonPropertyName("wind_kph")]
        public decimal WindKPH { get; set; }
    }
}
