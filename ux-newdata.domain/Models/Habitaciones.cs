using System;
using System.Collections.Generic;

namespace ux_newdata.domain.Models;

public partial class Habitaciones
{
    public Guid IdHabitacion { get; set; }

    public Guid? IdHotel { get; set; }

    public string NumeroHabitacion { get; set; } = null!;

    public string TipoHabitacion { get; set; } = null!;

    public decimal PrecioNoche { get; set; }

    public bool? Disponibilidad { get; set; }

    public short Capacidad { get; set; }

    public virtual Hoteles? IdHotelNavigation { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
