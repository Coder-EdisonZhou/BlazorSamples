using EDT.BlazorServer.App.Models;

namespace EDT.BlazorServer.App.Service.Contracts
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
