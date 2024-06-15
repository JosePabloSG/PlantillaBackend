using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class ViajeRequest
    {
        public int Id { get; set; }

        public int Lugar_salida { get; set; }

        public int Lugar_llegada { get; set;}

        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public int Precio { get; set; } 
    }
}
