# Weather API with CI/CD pipline

# Links
* [Trello](https://trello.com/b/XLzxepF2/v%C3%A4derapi)
* [Video](https://youtu.be/12A-cvWT6BY)

# Programming languages i used
* .NET 6 minimal Web api with Xunit
* React with Vite

# Data
I only used data from weatherapi.com

# Initial backlog

| Completed backlog |
|:------------------|
| Som användare av API:et vill jag kunna få aktuell väderdata(temperatur, luftfuktighet, vind) för Stockholm |
|Som användare av API:et vill jag kunna spara en favoritstad och slippa ange den varje gång (Obs att det bara ska sparas så länge appen körs, alltså inte mellan körningar)|
|Som systemägare vill jag kunna se om API:et körs (health check)|
|Som systemägare vill jag kunna se statistik på antal anrop sen API:et startades|
|Som slutanvändare av Reactklienten vill jag kunna se aktuellt väder för Stockholm|
|Som slutanvändare av Reactklienten vill jag kunna se och spara favoritstad|

# Azure Pipline
My azure pipline succeeded.

| Steps |
|:-------|
| Initialize job |
| Checkout Chasacademy-mostafa-shubber/WeatherAPI-Project@master to s |
|NuGetToolInstaller|
|NuGetCommand|
|VSBuild|
|VSTest|
|Post-job: Checkout Chasacademy-mostafa-shubber/WeatherAPI-Project@master to s|
|Finalize Job|

# Program.cs
In program.cs i have 4 methods
* app.MapGet("/weather": Get weather from Stockholm
* app.MapGet("/weather/favorite/{city}: Get weather from your favorite city
* app.MapGet("/health": Check the health
* app.MapGet("/stats": Check the stats of api calls

# Xunit
In xunit i have one method with url from weatherapi.com. 
