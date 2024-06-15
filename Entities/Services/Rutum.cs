using System;
using System.Collections.Generic;

namespace Entities.Services;

public partial class Rutum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Viaje> ViajeIdRuta1Navigations { get; set; } = new List<Viaje>();

    public virtual ICollection<Viaje> ViajeIdRuta2Navigations { get; set; } = new List<Viaje>();
}
