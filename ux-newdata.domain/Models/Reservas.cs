using System;
using System.Collections.Generic;

namespace ux_newdata.domain.Models;

public partial class Reservas
{
    public int IdReserva { get; set; }

    public Guid? IdUsuario { get; set; }

    public Guid? IdHhotel { get; set; }

    public Guid? IdHabitacion { get; set; }

    public DateOnly FechaEntrada { get; set; }

    public DateOnly FechaSalida { get; set; }

    public string? EstadoReserva { get; set; }

    public decimal PrecioTotal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Habitaciones? IdHabitacionNavigation { get; set; }

    public virtual Hoteles? IdHhotelNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
