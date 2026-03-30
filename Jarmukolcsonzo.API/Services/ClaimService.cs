using Jarmukolcsonzo.Shared.Models;
using System.Security.Claims;

namespace Jarmukolcsonzo.API.Services
{
    public static class ClaimService
    {
        public static int GetUserId(ClaimsPrincipal User)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (claimId != null)
            {
                return int.Parse(claimId.Value);
            }
            return 0;
        }

        public static List<Claim> GetClaimsFromUser(Felhasznalo felhasznalo)
        {
            return
            [
                new(ClaimTypes.NameIdentifier, felhasznalo.id.ToString()),
                new(ClaimTypes.Name, felhasznalo.felhasznalonev),
                new(ClaimTypes.Role, felhasznalo.szerepkor!.nev)
            ];
        }
    }
}
