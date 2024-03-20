using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Text.Json;
using WeatherAPI.Models;
using Xunit;

namespace WeatherAPI_Test
{
    public class APITest 
    {      

        [Fact]
        public async Task CheckAPI()
        {          
            var city = "Stockholm";
            var apiKey = "23ebc0730027475292d215347242202";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no");
          
            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(content);
            Assert.Equal(city, weatherData.Location.Name);


        }

       



    }
}