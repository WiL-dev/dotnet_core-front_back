using Microsoft.AspNetCore.Mvc;

using GXHAssessment.Web.Api.Helpers;
using GXHAssessment.Web.Api.Models;

namespace GXHAssessment.Web.Api.Controllers;

// [Port] Here is the detail about differences between ASPNET & ASPNET Core controllers
// https://learn.microsoft.com/en-us/dotnet/architecture/porting-existing-aspnet-apps/controller-differences
[ApiController]
[Route("[controller]")]
public class HealthCareProviderController: ControllerBase
{
    //TODO: Change to a dynamic url
    private const string BasePath = "https://npiregistry.cms.hhs.gov/api/?country_code=nz&limit=10&version=2.1";

    private readonly ILogger<HealthCareProviderController> _logger;

    public HealthCareProviderController(ILogger<HealthCareProviderController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<HealthCareProviderResult> Get()
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(BasePath);

            return await response.ReadContentAsync<HealthCareProviderResult>();
        }
    }
}