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
    
    public partial class Diagnoz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnoz()
        {
            this.Med_card = new HashSet<Med_card>();
            this.Plan_lecheniya = new HashSet<Plan_lecheniya>();
        }
    
        public int Id_diagnoza { get; set; }
        public string Name_diagnoza { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Med_card> Med_card { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plan_lecheniya> Plan_lecheniya { get; set; }
    }
}
