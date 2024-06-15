using System;
using System.Collections.Generic;

namespace Entities.Services;

public partial class Pasajero
{
    public int Id { get; set; }

    public int IdViaje { get; set; }

    public virtual Viaje IdViajeNavigation { get; set; } = null!;
}
