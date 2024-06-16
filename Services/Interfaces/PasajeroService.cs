

using Entities.Models;

namespace Services.Interfaces
{
    public class PasajeroService
    {
        private readonly ExamenContext _context;

        public PasajeroService(ExamenContext context)
        {
            _context = context;
        }


    }
}
