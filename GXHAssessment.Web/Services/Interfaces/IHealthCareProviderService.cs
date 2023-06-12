using GXHAssessment.Web.Models;

namespace GXHAssessment.Web.Services.Interfaces;

public interface IHealthCareProviderService
{
    Task<HealthCareProviderResultModel> Find();
}