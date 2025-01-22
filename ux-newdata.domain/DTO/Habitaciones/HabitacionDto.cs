namespace ux_newdata.domain.DTO.Habitaciones
{
    public class HabitacionDto
    {
        public Guid IdHabitacion { get; set; }

        public Guid? IdHotel { get; set; }

        public string NumeroHabitacion { get; set; } = null!;

        public string TipoHabitacion { get; set; } = null!;

        public decimal PrecioNoche { get; set; }

        public bool? Disponibilidad { get; set; }

        public short Capacidad { get; set; }
    }
}
