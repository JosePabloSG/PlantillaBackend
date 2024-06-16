using Entities.Models;

namespace Services.Interfaces
{
    public interface IPasajeros
    {
        Task<List<Pasajero>> GetPasajeros(DateTime date);
    }
}
