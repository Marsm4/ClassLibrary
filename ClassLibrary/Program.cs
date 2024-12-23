using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ClassLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // Регистрируем сервисы
            container.RegisterType<IVrachService, VrachService>();

            // Регистрируем ядро
            container.RegisterType<CoreApplication>();

            var coreApp = container.Resolve<CoreApplication>();


            Console.WriteLine("Врач добавлен!");
        }
    }
}
