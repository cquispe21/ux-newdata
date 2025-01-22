using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.DTO.Habitaciones;
using ux_newdata.domain.DTO.Usuario;
using ux_newdata.domain.Models;

namespace ux_newdata.infratructure.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDto, Usuarios>().ForMember(u => u.IdUsuario, x => x.MapFrom(x => Guid.NewGuid().ToString()));

            CreateMap<HabitacionDto, Habitaciones>();
        }
    }
}
