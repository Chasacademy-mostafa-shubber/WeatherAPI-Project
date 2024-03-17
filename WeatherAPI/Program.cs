using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherAPI.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHealthChecks();

builder.Services.AddSingleton<RequestCounter>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.MapGet("/weather", async () => 
{
    var requestCounter = app.Services.GetRequiredService<RequestCounter>();
    requestCounter.Increment();

    var apiKey = "23ebc0730027475292d215347242202";
    var city = "Stockholm";

    var httpClient = new HttpClient();
    
    var response = await httpClient.GetAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no");

    if (!response.IsSuccessStatusCode)
    {
        return Results.NotFound();
    }

    var content = await response.Content.ReadAsStringAsync();
    var weatherData = JsonSerializer.Deserialize<WeatherData>(content);
   
    return Results.Ok(weatherData);
});

app.MapGet("/weather/favorite/{city}", async (string city) =>
{
    var requestCounter = app.Services.GetRequiredService<RequestCounter>();
    requestCounter.Increment();
    var httpClient = new HttpClient();

    var apiKey = "23ebc0730027475292d215347242202";

    var response = await httpClient.GetAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no");

    if (!response.IsSuccessStatusCode)
    {
        return Results.NotFound();
    }

    var content = await response.Content.ReadAsStringAsync();
    var weatherData = JsonSerializer.Deserialize<WeatherData>(content);

    return Results.Ok(weatherData);
});


app.MapGet("/health", async (HealthCheckService healthCheckService) =>
{
    var healthReport = await healthCheckService.CheckHealthAsync();
    var status = healthReport.Status == HealthStatus.Healthy ? "Healthy" : "Unhealthy";
    var result = JsonSerializer.Serialize(new { Status = status });
    return Results.Ok(result);
});

app.MapGet("/stats", () =>
{
    var requestCounter = app.Services.GetRequiredService<RequestCounter>();
    var stats = new { TotalRequests = requestCounter.GetCount() };
    var statsJson = JsonSerializer.Serialize(stats);
    return Results.Ok(statsJson);
});


app.Run();




public class RequestCounter
{
    private int _count;

    public void Increment()
    {
        _count++;
    }

    public int GetCount()
    {
        return _count;
    }
}



