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

        public IEnumerable<Vrachs> GetAll()
        {
            return _context.Vrachs.ToList();
        }

        public Vrachs GetById(int id)
        {
            return _context.Vrachs.FirstOrDefault(e => e.Id_vracha == id);
        }

        public void Add(Vrachs ekzamens)
        {
            _context.Vrachs.Add(ekzamens);
            _context.SaveChanges();
        }

        public void Update(Vrachs ekzamens)
        {
            _context.Entry(ekzamens).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ekzamens = GetById(id);
            if (ekzamens != null)
            {
                _context.Vrachs.Remove(ekzamens);
                _context.SaveChanges();
            }
        }
    }
}
