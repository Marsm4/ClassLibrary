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
    
    public partial class Postyplenie
    {
        public int id_postypleniya { get; set; }
        public Nullable<int> Id_medcard { get; set; }
        public System.DateTime Data_postypleniya { get; set; }
        public Nullable<int> Id_type_postupleniya { get; set; }
    
        public virtual Med_card Med_card { get; set; }
        public virtual Type_postupleniya Type_postupleniya { get; set; }
    }
}
