using MeteoTrentoModels;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;

namespace WeatherTrentoService.Logic
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        List<WeatherForecast> GetForecastsByDate(string date);
    }

    public class WeatherService : IWeatherService
    {
        public List<WeatherForecast> GetForecastsByDate(string date)
        {
            var forecasts = MeteoTrentoService.DataReader.GetForecasts().Result;
            var forecastsForDate = forecasts.Where(f => f.Date == date).ToList();
            return forecastsForDate;
        }
    }
}