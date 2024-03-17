import React, { useState } from 'react';
import axios from 'axios';

function FavoriteCity() {
    const [city, setCity] = useState('');
    const [weatherData, setWeatherData] = useState(null);
    const [error, setError] = useState(null);

    const handleCityChange = (e) => {
        setCity(e.target.value);
    };

    const fetchWeatherData = async () => {
        try {
            const response = await axios.get(`https://localhost:7059/weather/favorite/${city}`);
            setWeatherData(response.data);
            setError(null);
        } catch (error) {
            setError('Failed to retrieve weather data');
            setWeatherData(null);
        }
    };

    return (
        <div>
            <input type="text" placeholder="Select city" value={city} onChange={handleCityChange} />
            <br></br>
            <button onClick={fetchWeatherData}>Get Weather</button>
            {error && <p>{error}</p>}
            {weatherData && (
                <div>
                    <h2>Weather for {weatherData.location.name}</h2>
                    <p>Temp C: {weatherData.current.temp_c}</p>
                    <p>Temp F: {weatherData.current.temp_f}</p>
                    <p>Humidity: {weatherData.current.humidity}</p>
                    <p>Wind MPH: {weatherData.current.wind_mph}</p>
                    <p>Wind KPH: {weatherData.current.wind_kph}</p>
                </div>
            )}
        </div>
    );
}

export default FavoriteCity;