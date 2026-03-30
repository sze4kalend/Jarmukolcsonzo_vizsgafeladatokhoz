using Jarmukolcsonzo.API.Data;
using Jarmukolcsonzo.API.Models;
using Jarmukolcsonzo.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jarmukolcsonzo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JKContext _context;
        public TokenController(JKContext context)
        {
            _context = context;
        }
    // Post: api/Token/Login
    
    
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto login)
        {
            //Felhasználó keresésée
            Felhasznalo? dbUser = await _context.felhasznalok.Include(x => x.szerepkor).FirstOrDefaultAsync(x => x.felhasznalonev == login.Username);
            if (dbUser == null)
            {
                return Unauthorized("A felhasználó nincs regisztrálva");//401
            }
            //Jelszó ellenőrzése
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(login.Password);
            return Ok();
        }
    }
}
