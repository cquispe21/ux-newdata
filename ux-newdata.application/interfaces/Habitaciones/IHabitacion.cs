using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.DTO.Habitaciones;

namespace ux_newdata.application.interfaces.Habitaciones
{
    public interface IHabitacion
    {
        Task<bool> AgregarHabitacion(HabitacionDto habitacion);
        Task<bool> ActualizarHabitacion(HabitacionDto habitacion);
        Task<bool> EliminarHabitacion(int id);
        Task<IEnumerable<HabitacionDto>> ObtenerHabitaciones();
        Task<HabitacionDto> ObtenerHabitacionPorId(Guid id);
       
    }
}
