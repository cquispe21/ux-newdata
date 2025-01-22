using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.DTO.Usuario;

namespace ux_newdata.application.interfaces.Usuario
{
    public interface IUsuario
    {
        Task<bool> AgregarUser(UsuarioDto usuario);
    }
}
