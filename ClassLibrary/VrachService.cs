using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class VrachService : IVrachService
    {
        private readonly ApplicationDbContext _context;

        public VrachService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vrach> GetAll()
        {
            return _context.Vrachs.ToList();
        }

        public Vrach GetById(int id)
        {
            return _context.Vrachs.FirstOrDefault(e => e.Id_vracha == id);
        }

        public void Add(Vrach vrach)
        {
            _context.Vrachs.Add(vrach);
            _context.SaveChanges();
        }

        public void Update(Vrach vrachs)
        {
            _context.Entry(vrachs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var vrachs = GetById(id);
            if (vrachs != null)
            {
                _context.Vrachs.Remove(vrachs);
                _context.SaveChanges();
            }
        }
    }
}
