using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces.Usuario;
using ux_newdata.domain.DTO.ApiResponse;
using ux_newdata.domain.DTO.Usuario;
using ux_newdata.domain.Models;
using ux_newdata.infratructure.Context;
using ux_newdata.infratructure.utils;

namespace ux_newdata.infratructure.Repository.Usuario
{
    public class UsuarioRepository_cs : IUsuario
    {
        private readonly _contextApi _contextApi;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioRepository_cs> _logger;

        public UsuarioRepository_cs(_contextApi contextApi, IMapper mapper, ILogger<UsuarioRepository_cs> logger)
        {
            _contextApi = contextApi;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> AgregarUser(UsuarioDto usuario)
        {
            try{
                var existe = await _contextApi.Usuarios.FirstOrDefaultAsync(x => x.Correo == usuario.Correo);
                if (existe != null)
                {
                    return false;
                }
                usuario.Salt = Encrypt.GenerateSalt();
                usuario.Clave = Encrypt.HashPassword(usuario.Clave, usuario.Salt);
                var mapper = _mapper.Map<Usuarios>(usuario);
                _contextApi.Usuarios.Add(mapper);
                await _contextApi.SaveChangesAsync();
                _logger.LogWarning("Usuario agregado");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }



        }
    }
}
