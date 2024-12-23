using Clinical_Hospital_33.Models;

namespace WebApplication3
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
