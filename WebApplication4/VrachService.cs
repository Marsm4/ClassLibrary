using Clinical_Hospital_33.Models;
using Clinical_Hospital_33.Repositories;
using IVrachRepository = Clinical_Hospital_33.Models.IVrachRepository;

namespace Clinical_Hospital_33.Services
{
    public class VrachService : IVrachService
    {
        private readonly IVrachRepository _vrachRepository;

        public VrachService(IVrachRepository vrachRepository)
        {
            _vrachRepository = vrachRepository;
        }

        public async Task<IEnumerable<Vrach>> GetAllVrach()
        {
            return await _vrachRepository.GetAll();
        }

        public async Task<Vrach> GetVrachById(int id)
        {
            return await _vrachRepository.GetById(id);
        }

        public async Task AddVrach(Vrach vrach)
        {
            await _vrachRepository.Add(vrach);
        }

        public async Task UpdateVrach(Vrach vrach)
        {
            await _vrachRepository.Update(vrach);
        }

        public async Task DeleteVrach(int id)
        {
            await _vrachRepository.Delete(id);
        }
    }

    public interface IVrachService
    {
        Task<IEnumerable<Vrach>> GetAllVrach();
        Task<Vrach> GetVrachById(int id);
        Task AddVrach(Vrach vrach);
        Task UpdateVrach(Vrach vrach);
        Task DeleteVrach(int id);
    }
}