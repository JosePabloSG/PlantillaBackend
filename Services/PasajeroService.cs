

using Entities.Models;

namespace Services
{
    public class PasajeroService
    {
        private readonly ExamenContext _context;

        public PasajeroService(ExamenContext context)
        {
            _context = context;
        }

        public async Task<List<Pasajero>> GetPasajeros(DateTime date)
        {
            var viajesenFecha = await _context.Viajes
                .where(k => k.fecha.date == date.Date)
                .ToListAsync();

            var viajesId = viajesenFecha.Select(k => k.id).ToList();

            var pasajeros = await _context.Pasajeros
                .where(s => viajesId.Contains(s.id))
                .toListAsync();

            int conteo = pasajeros.Count;

            return pasajeros;
        }
    }
}
