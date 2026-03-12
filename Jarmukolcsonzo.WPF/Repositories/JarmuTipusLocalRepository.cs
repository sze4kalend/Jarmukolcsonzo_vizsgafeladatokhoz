using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.Repositories;

namespace Jarmukolcsonzo.WPF.Repositories
{
    public class JarmuTipusLocalRepository : IGenericRepository<JarmuTipus>
    {
        private List<JarmuTipus> jarmuTipusok = [];

        public Task<List<JarmuTipus>?> GetAllAsync()
        {
            Random random = new();
            for (int i = 1; i <= 20; i++)
            {
                jarmuTipusok.Add(new JarmuTipus
                {
                    id = i,
                    megnevezes = "Típus " + i,
                    ferohely = random.Next(2, 8)
                });
            }
            // Task visszaadása szinkronos módon (nem aszinkron feladat)
            return Task.FromResult<List<JarmuTipus>?>(jarmuTipusok);
        }

        public Task<JarmuTipus?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JarmuTipus?> InsertAsync(JarmuTipus entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, JarmuTipus Entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
