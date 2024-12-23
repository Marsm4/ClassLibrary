using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Table("Vrachs")]
    public class Vrach
    {
        [Key]
        public int Id_vracha { get; set; }
        public char Familya { get; set; }
        public char Name { get; set; }
        public int id_doljnosti { get; set; }
        public char Otchestvo { get; set; }
        public int Id_gender { get; set; }
        public DateTime Data_rojdeniya { get; set; }
    }
}
