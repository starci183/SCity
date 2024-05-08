
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

public delegate Task HandleHttpException(HttpResponseMessage responseObject);
public static class HttpUtility
{
    public static async Task<TResponse> GetAsync<TResponse>(
        string url, 
        HandleHttpException HandleHttpException = null
        ) where TResponse : class
    {
        using var httpClient = new HttpClient();
        var responseObject = await httpClient.GetAsync(url);

        if (responseObject.IsSuccessStatusCode)
        {
            var responseContent = await responseObject.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        } else
        {
            if (HandleHttpException != null)
            {
                await HandleHttpException(responseObject);
            }
            return null;
        }
    }

    public static async Task<TResponse> PostAsync<TRequest, TResponse>(
        string url,
        TRequest request,
        HandleHttpException HandleHttpException = null
        ) where TRequest : class where TResponse : class
    {
        using var httpClient = new HttpClient();
        var requestContent = new StringContent(JsonConvert.SerializeObject(request));
        var responseObject = await httpClient.PostAsync(url, requestContent);

        if (responseObject.IsSuccessStatusCode)
        {
            var responseContent = await responseObject.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
        else
        {
            if (HandleHttpException != null)
            {
                await HandleHttpException(responseObject);
            }
            return null;
        }
    }
}