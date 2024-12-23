using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CoreApplication
    {
        private readonly IVrachService _vrachService;

        public CoreApplication(
             IVrachService vrachService)
        {
            _vrachService = vrachService;
        }
        public IEnumerable<Vrach> GetAllEkzamens()
        {
            return _vrachService.GetAll();
        }

        public Vrach GetEkzamenById(int id)
        {
            return _vrachService.GetById(id);
        }

        public void AddEkzamen(Vrach ekzamens)
        {
            _vrachService.Add(ekzamens);
        }

        public void UpdateEkzamen(Vrach ekzamens)
        {
            _vrachService.Update(ekzamens);
        }

        public void DeleteEkzamen(int id)
        {
            _vrachService.Delete(id);
        }
    }
}
