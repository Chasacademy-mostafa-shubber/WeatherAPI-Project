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
        public async Task GetWeatherStockholm()
        {          
            var city = "Stockholm";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7059/weather");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(content);
            Assert.Equal(city, weatherData.Location.Name);


        }

        [Fact]
        public async Task GetFavoriteCity()
        {
         
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7059/weather/favorite/{city}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        }

        [Fact]
        public async void CheckHealth()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7059/health");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void CheckStats()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7059/stats");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }



    }
}