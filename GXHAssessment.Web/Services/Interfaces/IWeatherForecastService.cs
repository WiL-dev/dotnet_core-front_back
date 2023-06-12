using GXHAssessment.Web.Models;

namespace GXHAssessment.Web.Services.Interfaces;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecastModel>> Find();
}