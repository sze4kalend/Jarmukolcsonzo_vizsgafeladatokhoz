using Jarmukolcsonzo.Shared.DTOs;
using Jarmukolcsonzo.Shared.Repositories;
using System.Net.Http.Json;

namespace ApiClient.Repositories
{
    public class DataTableApiRepository<T> : GenericApiRepository<T>, IDataTableRepository<T>
    {
        public DataTableApiRepository(string baseUrl, string path, DelegatingHandler? handler = null) : base(baseUrl, path, handler)
        {
        }

        public async Task<TableDto<T>> GetAllAsync(
            int page = 1, int itemsPerPage = 25,
            string? search = null, string? sortBy = null,
            bool ascending = true)
        {
            // Hozzáadja a query paramétereket
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "itemsPerPage", itemsPerPage.ToString() }
            };
            if (search is not null)
            {
                queryParameters.Add("searchKey", search);
            }
            if (sortBy is not null)
            {
                queryParameters.Add("sortKey", sortBy);
                queryParameters.Add("ascending", ascending.ToString());
            }
            // Összefűzi a paramétereket URL kódolásban
            FormUrlEncodedContent dictFormUrlEncoded = new(queryParameters);
            string queryString = await dictFormUrlEncoded.ReadAsStringAsync();

            return await Client.GetFromJsonAsync<TableDto<T>?>($"{Path}?{queryString}") ?? new TableDto<T>(null, 0);
        }
    }
}
