using Microsoft.AspNetCore.Mvc;
using GXHAssessment.Web.Services.Interfaces;

namespace GXHAssessment.Web.Controllers;

public class WeatherForecastController : Controller
{
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<IActionResult> WeatherForecastIndex()
    {
        var products = await _service.Find();
        return View(products);
    }
}