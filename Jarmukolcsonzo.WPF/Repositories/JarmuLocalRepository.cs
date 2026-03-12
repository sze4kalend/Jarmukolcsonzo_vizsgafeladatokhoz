using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.Repositories;

namespace Jarmukolcsonzo.WPF.Repositories
{
    public class JarmuLocalRepository : IGenericRepository<Jarmu>
    {
        private List<Jarmu> jarmuvek;
        private List<JarmuTipus> jarmuTipusok;

        public JarmuLocalRepository()
        {
            jarmuvek = [];
            // ?? [] = Ha NULL az eredmény, akkor hozzon létre egy üres listát
            jarmuTipusok = new JarmuTipusLocalRepository().GetAllAsync().Result ?? [];
        }

        public Task<List<Jarmu>?> GetAllAsync()
        {
            Random random = new();
            for (int i = 1; i <= 100 ; i++)
            {
                int jarmuTipusId = random.Next(1, 21);
                jarmuvek.Add(new Jarmu
                {
                    id = i,
                    rendszam = $"ABC-{i:000}", // ABC-001
                    dij = random.Next(10000, 35001),
                    elerheto = random.Next(0, 2) == 1, // Egyenlő-e 1-el
                    szerviz_datum = DateTime.Now,
                    tipus_id = jarmuTipusId,
                    tipus = jarmuTipusok.First(x => x.id == jarmuTipusId) 
                    // First = keresés, ha nincs találat akkor Exception-t dob
                });
            }

            return Task.FromResult<List<Jarmu>?>(jarmuvek);
        }

        public Task<Jarmu?> GetByIdAsync(int id)
        {
            var entity = jarmuvek.FirstOrDefault(x => x.id == id);
            return Task.FromResult(entity);
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            bool exists = jarmuvek.Any(x => x.id == id);
            return Task.FromResult(exists);
        }

        public Task<Jarmu?> InsertAsync(Jarmu entity)
        {
            entity.id = jarmuvek.Max(x => x.id) + 1;
            jarmuvek.Insert(0, entity); // A legelső helyre szúrja be
            return Task.FromResult<Jarmu?>(entity);
        }

        public Task UpdateAsync(int id, Jarmu entity)
        {
            int index = jarmuvek.FindIndex(x => x.id == id);
            if (index != 0)
            {
                jarmuvek[index] = entity;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var entity = jarmuvek.FirstOrDefault(x => x.id == id);
            if (entity != null)
            {
                jarmuvek.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}
