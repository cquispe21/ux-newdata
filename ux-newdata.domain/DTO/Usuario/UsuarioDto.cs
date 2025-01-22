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
        public Guid IdUsuario { get; set; }

        public string NombresCompletos { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? Telefono { get; set; }

        public string Correo { get; set; } = null!;


        public string Clave { get; set; } = null!;

        [JsonIgnore]
        public string? Salt { get; set; }

        public string? TipoUsuario { get; set; }

   
    }
}
