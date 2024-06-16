

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


    }
}
