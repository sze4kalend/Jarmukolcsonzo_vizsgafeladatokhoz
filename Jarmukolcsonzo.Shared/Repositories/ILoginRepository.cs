using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmukolcsonzo.Shared.Repositories
{
    public interface ILoginRepository
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
