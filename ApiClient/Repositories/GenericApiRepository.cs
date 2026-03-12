using Jarmukolcsonzo.Shared.Repositories;
using System.Net.Http.Json;

namespace ApiClient.Repositories
{
    public class GenericApiRepository<T> : BaseApiRepository, IGenericRepository<T>
    {
        public GenericApiRepository(string baseUrl, string path, DelegatingHandler? handler = null) : base(baseUrl, path, handler)
        {
        }

        public async Task<List<T>?> GetAllAsync()
        {
            return await Client.GetFromJsonAsync<List<T>>(Path);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await Client.GetFromJsonAsync<T>(Path + "/" + id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await Client.GetAsync(Path + "/" + id);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<T?> InsertAsync(T entity)
        {
            HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(Path, entity);
            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await Client.PutAsJsonAsync(Path + "/" + id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await Client.DeleteAsync(Path + "/" + id);
        }
    }
}
