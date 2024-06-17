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
            var query1 = _context.Viajes.AsQueryable();
            var query2 = _context.Viajes.AsQueryable();

            if (lugarSalida.HasValue)
            {
                query1 = query1.Where(v => v.IdRuta1 == lugarSalida.Value );
                query2 = query2.Where(v => v.IdRuta2 == lugarSalida.Value);
            }



            if (lugarLlegada.HasValue)
            {
                query1 = query1.Where(v => v.IdRuta2 == lugarLlegada.Value);
                query2 = query2.Where(v => v.IdRuta1 == lugarLlegada.Value);

            }

            if (fechaInicio.HasValue)
            {
                query1 = query1.Where(v => v.Fecha >= fechaInicio.Value);
                query2 = query2.Where(v => v.Fecha >= fechaInicio.Value);
            }


            if (fechaFin.HasValue)
            {
                query1 = query1.Where(v => v.Fecha <= fechaFin.Value);
                query2 = query2.Where(v => v.Fecha <= fechaFin.Value);
            }


            var cantidadPasajeros = query1.Count() + query2.Count();
            var dineroRecolectado = query1.Sum(v => v.Precio) + query2.Sum(v => v.Precio);

            return new FiltradoResponse
            {
                CantidadPasajeros = cantidadPasajeros,
                DineroRecolectado = dineroRecolectado
            };
        }
    }


}
