using Clinical_Hospital_33.Models;

namespace Clinical_Hospital_33.Models
{
    public interface IVrachRepository
    {
        Task<IEnumerable<Vrach>> GetAll();
        Task<Vrach> GetById(int id);
        Task Add(Vrach vrach);
        Task Update(Vrach vrach);
        Task Delete(int id);
    }
}
