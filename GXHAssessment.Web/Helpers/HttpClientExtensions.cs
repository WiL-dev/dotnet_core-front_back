using System.Text.Json;

namespace GXHAssessment.Web.Helpers;

public static class HttpClientExtensions
{
    // Extension methods
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode == false)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var result = JsonSerializer.Deserialize<T>(
            dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        //TODO: Add a better "result == null" management
        if (result == null)
            throw new ApplicationException("No results calling the api API");

        return result;
    }
}