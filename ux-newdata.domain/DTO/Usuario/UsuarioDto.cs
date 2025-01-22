using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ux_newdata.domain.DTO.Usuario
{
    public class UsuarioDto
    {
        [JsonIgnore]
        public string? IdUsuario { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; } = null!;
        [JsonIgnore]
        public string? Salt { get; set; }
    }
}
