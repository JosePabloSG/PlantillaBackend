using Entities.Models;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IViaje
    {
        Task<List<Viaje>> GetViajes();

        Task<ViajeRequest> PostViajes(ViajeRequest viajeRequest);


        public bool HasViajeTheSameDay(ViajeRequest viajeRequest);
    }
}
