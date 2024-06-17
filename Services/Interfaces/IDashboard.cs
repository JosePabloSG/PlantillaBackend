using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Interfaces
{
    public interface IDashboardService
    {
        FiltradoResponse FiltrarDatos(int? lugarSalida, int? lugarLlegada, DateTime? fechaInicio, DateTime? fechaFin);
    }


}
