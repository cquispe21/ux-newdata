using System;
using System.Collections.Generic;

namespace ux_newdata.domain.Models;

public partial class Hoteles
{
    public Guid IdHotel { get; set; }

    public string NombreHotel { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public short? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public string? Politicas { get; set; }

    public string? Contacto { get; set; }

    public virtual ICollection<Habitaciones> Habitaciones { get; set; } = new List<Habitaciones>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
