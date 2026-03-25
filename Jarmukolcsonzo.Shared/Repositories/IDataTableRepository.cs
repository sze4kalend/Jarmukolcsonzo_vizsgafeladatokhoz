using Jarmukolcsonzo.Shared.DTOs;

namespace Jarmukolcsonzo.Shared.Repositories
{
    public interface IDataTableRepository<T> : IGenericRepository<T>
    {
        Task<TableDto<T>> GetAllAsync(
            int page = 1,
            int itemsPerPage = 25,
            string? searchKey = null,
            string? sortKey = null,
            bool ascending = true


            );
    }
}
