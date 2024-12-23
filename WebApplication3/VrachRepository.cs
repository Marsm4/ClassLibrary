using Microsoft.EntityFrameworkCore;
using Clinical_Hospital_33.Data;
using Clinical_Hospital_33.Models;

namespace Clinical_Hospital_33.Repositories
{
    public class VrachRepository : IVrachRepository
    {
        private readonly ApplicationDbContext _context;

        public VrachRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vrach>> GetAll()
        {
            return await _context.Vrach.ToListAsync();
        }

        public async Task<Vrach> GetById(int id)
        {
            return await _context.Vrach.FindAsync(id);
        }

        public async Task Add(Vrach vrach)
        {
            _context.Vrach.Add(vrach);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vrach vrach)
        {
            _context.Entry(vrach).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vrach = await _context.Vrach.FindAsync(id);
            if (vrach != null)
            {
                _context.Vrach.Remove(vrach);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IVrachRepository
    {
        Task<IEnumerable<Vrach>> GetAll();
        Task<Vrach> GetById(int id);
        Task Add(Vrach vrach);
        Task Update(Vrach vrach);
        Task Delete(int id);
    }
}