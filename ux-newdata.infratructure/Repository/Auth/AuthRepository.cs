using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces.Auth;
using ux_newdata.domain.DTO.Aut;
using ux_newdata.infratructure.Context;
using ux_newdata.infratructure.utils;

namespace ux_newdata.infratructure.Repository.Auth
{
    public class AuthRepository : ÍAuth
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly _contextApi _context;

        public AuthRepository(IMapper mapper, IConfiguration config,_contextApi context)
        {
            _mapper = mapper;
            _config = config;
            _context = context;
        }
        public async Task<AuthDto> AutenticacionLogin(LoginDto login)
        {
            try
            {
                var validateUser = await _context.Usuarios.Where(x => x.UserName == login.userName).FirstOrDefaultAsync();
                if (validateUser != null)
                {
                    string newHashedPassword = Encrypt.HashPassword(login.password, validateUser.Salt);

                    if (validateUser.Clave == newHashedPassword)
                    {
                        var token = GenerateToken.CreateToken(validateUser.IdUsuario.ToString());
                        return new AuthDto
                        {
                            Resultado = true,
                            Token = token,
                            Messaje = "Autenticación exitosa"
                        };
                    }

                }
                return new AuthDto
                {
                    Resultado = false,
                    Messaje = "Nombre de usuario o contraseña incorrectos"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la autenticación", ex);


            }
    }
    }
}
