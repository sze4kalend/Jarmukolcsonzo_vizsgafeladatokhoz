using System.Net.Http.Headers;

namespace ApiClient.Repositories
{
    public abstract class BaseApiRepository
    {
        protected readonly HttpClient Client;
        protected readonly string? Path;

        protected BaseApiRepository(string baseUrl, string? path = null, DelegatingHandler? handler = null)
        {
            Path = path;
            Client = handler is null ? new HttpClient(): new HttpClient(handler);
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
