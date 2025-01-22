using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces.Habitaciones;
using ux_newdata.domain.DTO.Habitaciones;
using ux_newdata.domain.Models;
using ux_newdata.infratructure.Context;

namespace ux_newdata.infratructure.Repository.Habitacion
{
    public class HabitacionRepository : IHabitacion
    {
        private readonly _contextApi _contextApi;
        private readonly IMapper _mapper;

        public HabitacionRepository(_contextApi contextApi, IMapper mapper)
        {
            _contextApi = contextApi;
            _mapper = mapper;
        }

        public async Task<bool> AgregarHabitacion(HabitacionDto habitacion)
        {
            var mapper = _mapper.Map<Habitaciones>(habitacion);
            _contextApi.Habitaciones.Add(mapper);
            await _contextApi.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarHabitacion(HabitacionDto habitacion)
        {

            var mapper = _mapper.Map<Habitaciones>(habitacion);
            _contextApi.Habitaciones.Update(mapper);
            await _contextApi.SaveChangesAsync();
            return true;
        }
        public Task<bool> EliminarHabitacion(int id)
        {
            throw new NotImplementedException();

        }
        public async Task<IEnumerable<HabitacionDto>> ObtenerHabitaciones()
        {
            return _mapper.Map<IEnumerable<HabitacionDto>>(await _contextApi.Habitaciones.ToListAsync());
        }
        public async Task<HabitacionDto> ObtenerHabitacionPorId(Guid id)
        {
            return _mapper.Map<HabitacionDto>(await _contextApi.Habitaciones.FirstOrDefaultAsync(x => x.IdHabitacion == id));
        }
       
    }
}
