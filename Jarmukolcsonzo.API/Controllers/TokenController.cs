using Jarmukolcsonzo.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jarmukolcsonzo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    // Post: api/Token/Login
    {
        [HttpPost("Login")]
        public ActionResult Login(LoginDto login)
        {

            return Ok();
        }
    }
}
