using Entities.Models;
using Entities.Services;
using Services.Interfaces;

namespace Services
{
    public class ViajeService : IViaje
    {

        private readonly ExamenContext _context;
        private readonly IPasajeros _pasajeros;

        public ViajeService(ExamenContext context, IPasajeros pasajeros)
        {
            _context = context;
            _pasajeros = pasajeros;
        }

        async public Task<List<Viaje>> GetViajes()
        {

            var ListViajes = _context.Viajes.ToList(); 

            var List = ListViajes.Select(item => new ViajeRequest
                {
                    Id = item.Id,
                    Fecha = new DateOnly(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day),
                    Hora = new TimeOnly(item.Fecha.Hour,item.Fecha.Minute),
                    Lugar_llegada = item.IdRuta2,
                    Lugar_salida = item.IdRuta1,
                    Precio = 0,
            }).ToList();


            return ListViajes;
        }

        public bool HasViajeTheSameDay(ViajeRequest viajeRequest)
        {

            var Viaje = _context.Viajes.Where(item => item.Fecha.Day == viajeRequest.Fecha.Day
            && item.Fecha.Month == viajeRequest.Fecha.Month && item.Fecha.Year == viajeRequest.Fecha.Year);
            if (Viaje == null)
            {
                return false;
            }
            return true;
        }

        public int ObtenerPrecio(int salida, int destino)
        {
            if (salida == 1 && destino == 2 || destino == 1 && salida == 2)
            {
                return 500;
            }
            else if (salida == 2 && destino == 3 || salida == 2 && destino == 3)
            {
                return 1000;
            }
            else
            {
                return 1500;
            }

        }

        async public Task<ViajeRequest> PostViajes(ViajeRequest viajeRequest)
        {
            DateTime date = new DateTime(viajeRequest.Fecha, viajeRequest.Hora);
            var ListPasajero = await _pasajeros.GetPasajeros(date);

            if (ListPasajero.Count >= 10 )
            {
                return null;
            }

            viajeRequest.Precio = ObtenerPrecio(viajeRequest.Lugar_salida, viajeRequest.Lugar_llegada);

            Viaje viaje = new Viaje {IdRuta1 = viajeRequest.Lugar_salida, IdRuta2 = viajeRequest.Lugar_llegada,
                Fecha = new DateTime(viajeRequest.Fecha, viajeRequest.Hora), Precio = viajeRequest.Precio};



            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();
            Pasajero pasajero = new Pasajero { IdViaje = viaje.Id };
            _context.Pasajeros.Add(pasajero);
            await _context.SaveChangesAsync();



            return viajeRequest;

            
        }
    }
}
