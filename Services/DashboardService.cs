using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ExamenContext _context;

        public DashboardService(ExamenContext context)
        {
            _context = context;
        }

        public FiltradoResponse FiltrarDatos(int? lugarSalida, int? lugarLlegada, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var query = _context.Viajes.AsQueryable();

            if (lugarSalida.HasValue)
            {
                query = query.Where(v => v.IdRuta1 == lugarSalida.Value);
            }

            if (lugarLlegada.HasValue)
            {
                query = query.Where(v => v.IdRuta2 == lugarLlegada.Value);
            }

            if (fechaInicio.HasValue)
            {
                query = query.Where(v => v.Fecha >= fechaInicio.Value);
            }

            if (fechaFin.HasValue)
            {
                query = query.Where(v => v.Fecha <= fechaFin.Value);
            }

            var cantidadPasajeros = query.Count();
            var dineroRecolectado = query.Sum(v => v.Precio);

            return new FiltradoResponse
            {
                CantidadPasajeros = cantidadPasajeros,
                DineroRecolectado = dineroRecolectado
            };
        }
    }


}
