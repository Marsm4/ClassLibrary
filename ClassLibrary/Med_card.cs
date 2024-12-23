//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Med_card
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Med_card()
        {
            this.Postyplenie = new HashSet<Postyplenie>();
            this.Vipiska = new HashSet<Vipiska>();
        }
    
        public int Id_medcard { get; set; }
        public string Familya { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public Nullable<int> Id_gender { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Id_grupa_krovi { get; set; }
        public Nullable<int> Id_diagnoza { get; set; }
        public Nullable<int> Number_palaty { get; set; }
        public Nullable<int> Id_vracha { get; set; }
        public string Hair_color { get; set; }
        public string Primety { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
    
        public virtual Diagnoz Diagnoz { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Grupa_krovi Grupa_krovi { get; set; }
        public virtual Vrach Vrach { get; set; }
        public virtual Palata Palata { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postyplenie> Postyplenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vipiska> Vipiska { get; set; }
    }
}
