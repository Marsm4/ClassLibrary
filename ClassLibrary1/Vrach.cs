//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vrach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vrach()
        {
            this.Med_card = new HashSet<Med_card>();
        }
    
        public int Id_vracha { get; set; }
        public string Familya { get; set; }
        public string Name { get; set; }
        public Nullable<int> id_doljnosti { get; set; }
        public string Otchestvo { get; set; }
        public Nullable<int> Id_gender { get; set; }
        public System.DateTime Data_rojdeniya { get; set; }
        public string Phone { get; set; }
        public decimal Oklad { get; set; }
        public decimal Nadbavka { get; set; }
    
        public virtual Doljnost Doljnost { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Med_card> Med_card { get; set; }
    }
}
