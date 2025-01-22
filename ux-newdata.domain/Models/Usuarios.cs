using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ux_newdata.domain.Models
{
    public partial class Usuarios
    {
        public Guid IdUsuario { get; set; }

        public string NombresCompletos { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? Telefono { get; set; }

        public string Correo { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public string? TipoUsuario { get; set; }

        public string Salt { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
    }
}
