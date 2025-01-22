using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces.Usuario;
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

        public UsuarioRepository_cs(_contextApi contextApi, IMapper mapper)
        {
            _contextApi = contextApi;
            _mapper = mapper;
        }

        public async Task<bool> AgregarUser(UsuarioDto usuario)
        {
            var existe = await _contextApi.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (existe != null)
            {
                return false;
            }
            usuario.Salt = Encrypt.GenerateSalt();
            usuario.Password = Encrypt.HashPassword(usuario.Password, usuario.Salt);
            var mapper = _mapper.Map<Usuarios>(usuario);
            _contextApi.Usuarios.Add(mapper);
            await _contextApi.SaveChangesAsync();
            return true;

        }
    }
}
