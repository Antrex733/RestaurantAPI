namespace RestaurantAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int min, int max, int ile);
        IEnumerable<WeatherForecast> Get();
    }
}