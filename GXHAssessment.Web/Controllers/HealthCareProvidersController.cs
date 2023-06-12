using Microsoft.AspNetCore.Mvc;
using GXHAssessment.Web.Services.Interfaces;

namespace GXHAssessment.Web.Controllers;

public class HealthCareProvidersController : Controller
{
    private readonly IHealthCareProviderService _service;

    public HealthCareProvidersController(IHealthCareProviderService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<IActionResult> HealthCareProvidersIndex()
    {
        var healthCareProviders = await _service.Find();
        return View(healthCareProviders);
    }
}