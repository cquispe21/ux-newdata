using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ux_newdata.application.interfaces.Usuario;
using ux_newdata.domain.DTO.Usuario;

namespace ux_newdata.api.Controllers.Usuario
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        [Authorize]
        [HttpPost]
        [Route("agregar")]
        public async Task<IActionResult> Agregar([FromBody] UsuarioDto usuario)
        {
            var result = await _usuario.AgregarUser(usuario);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
