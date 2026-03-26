using Jarmukolcsonzo.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmukolcsonzo.WPF.Repositories
{
    public class LoginLocalRepository : ILoginRepository

    {
        public Task<string> AuthenticateAsync(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return Task.FromResult(string.Empty);
            }
            return Task.FromResult("Hibás felhasználóné vagy jelszó");
        }
    }
}
