

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services
{
    public class PasajeroService : IPasajeros
    {
        private readonly ExamenContext _context;

        public PasajeroService(ExamenContext context)
        {
            _context = context;
        }

        public async Task<List<Pasajero>> GetPasajeros(DateTime date)
        {
            var viajesenFecha = await _context.Viajes
                .Where(k => k.Fecha.Date == date.Date)
                .ToListAsync();

            var viajesId = viajesenFecha.Select(k => k.Id).ToList();

            var pasajeros = await _context.Pasajeros
                .Where(s => viajesId.Contains(s.Id))
                .ToListAsync();

            int conteo = pasajeros.Count;

            return pasajeros;
        }
    }
}
