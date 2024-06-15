using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RutasService : IRutum
    {
        private readonly ExamenContext _context;

        public RutasService(ExamenContext context)
        {
            _context = context;
        }

        async public Task<List<Rutum>> GetRutas()
        {

            var lista =  _context.Ruta.ToListAsync();
            return await lista;
        }
    }
}
