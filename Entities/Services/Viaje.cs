using System;
using System.Collections.Generic;

namespace Entities.Services;

public partial class Viaje
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int IdRuta1 { get; set; }

    public int IdRuta2 { get; set; }

    public virtual Rutum IdRuta1Navigation { get; set; } = null!;

    public virtual Rutum IdRuta2Navigation { get; set; } = null!;

    public virtual ICollection<Pasajero> Pasajeros { get; set; } = new List<Pasajero>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
