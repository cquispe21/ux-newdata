using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ux_newdata.domain.Models
{
    public partial class Usuarios
    {
        public string IdUsuario { get; set; } = null!;

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }
}
