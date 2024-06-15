using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int IdRuta1 { get; set; }

    public int IdRuta2 { get; set; }

    public int Precio { get; set; }
}
