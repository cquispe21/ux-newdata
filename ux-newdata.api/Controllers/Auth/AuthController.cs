using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ux_newdata.application.interfaces.Auth;
using ux_newdata.domain.DTO.Aut;

namespace ux_newdata.api.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly ÍAuth _íAuth;
        public AuthController(ÍAuth íAuth)
        {
            _íAuth = íAuth;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await _íAuth.AutenticacionLogin(login);
            if (result == null)
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }
    }
}
