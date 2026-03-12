namespace Jarmukolcsonzo.Shared.Repositories
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Összes adat lekérdezése.
        /// </summary>
        /// <returns></returns>
        Task<List<T>?> GetAllAsync();

        /// <summary>
        /// Egy elem lekérdezése ID alapján.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Lekérdezi, hogy létezik-e az elem ID alapján.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(int id);

        /// <summary>
        /// Létrehoz egy elemet.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T?> InsertAsync(T entity);

        /// <summary>
        /// Frissíti az elemet ID és érték alapján.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, T Entity);

        /// <summary>
        /// Töröl egy elemet ID alapján.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
