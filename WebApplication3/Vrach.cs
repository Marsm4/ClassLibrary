using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinical_Hospital_33.Models
{
    [Table("Vrach")]
    public class Vrach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_vracha { get; set; }

        [Required]
        [StringLength(30)]
        public string Familya { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Otchestvo { get; set; }

        public int? Id_doljnosti { get; set; }

        public int? Id_gender { get; set; }

        [Required]
        public DateTime Data_rojdeniya { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Oklad { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Nadbavka { get; set; }
    }
}