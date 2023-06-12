using GXHAssessment.Web.Models;
using GXHAssessment.Web.Helpers;
using GXHAssessment.Web.Services.Interfaces;

namespace GXHAssessment.Web.Services;

public class HealthCareProviderService : IHealthCareProviderService
{
    private readonly HttpClient _client;
    public const string BasePath = "/HealthCareProvider";

    public HealthCareProviderService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<HealthCareProviderResultModel> Find()
    {
        var response = await _client.GetAsync(BasePath);

        return await response.ReadContentAsync<HealthCareProviderResultModel>();
    }
}