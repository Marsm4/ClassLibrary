using Clinical_Hospital_33.Models;

namespace Clinical_Hospital_33.Models
{
    public interface IVrachService
    {
        Task<IEnumerable<Vrach>> GetAllVrach();
        Task<Vrach> GetVrachById(int id);
        Task AddVrach(Vrach vrach);
        Task UpdateVrach(Vrach vrach);
        Task DeleteVrach(int id);
    }
}
