using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IVrachService
    {
        IEnumerable<Vrachs> GetAll();
        Vrachs GetById(int id);
        void Add(Vrachs vrachs);
        void Update(Vrachs vrachs);
        void Delete(int id);
    }
}
