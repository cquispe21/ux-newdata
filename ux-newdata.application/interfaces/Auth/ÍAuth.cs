using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.DTO.Aut;

namespace ux_newdata.application.interfaces.Auth
{
    public interface ÍAuth
    {
        Task<AuthDto> AutenticacionLogin(LoginDto login);
    }
}
