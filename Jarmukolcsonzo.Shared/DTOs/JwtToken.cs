using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmukolcsonzo.Shared.DTOs
{
    public record JwtToken(string AccesTokaen, string Refreshtoken);
}
