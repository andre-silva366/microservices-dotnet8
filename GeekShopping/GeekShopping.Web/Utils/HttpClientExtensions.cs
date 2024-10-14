using System.Text.Json;

namespace GeekShopping.Web.Utils;

public static class HttpClientExtensions
{
    public static async Task<T> RedContentAs<T>(this HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something wen wrong calling the API: {response.ReasonPhrase}");
        }

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize <T> (dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
