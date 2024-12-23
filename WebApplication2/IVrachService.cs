using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IVrachService
    {
        IEnumerable<Vrach> GetAll();
        Vrach GetById(int id);
        void Add(Vrach vrachs);
        void Update(Vrach vrachs);
        void Delete(int id);
    }
}
