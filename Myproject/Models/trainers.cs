//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Myproject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainers()
        {
            this.reservas = new HashSet<reservas>();
        }
    
        public int idpt { get; set; }
        public string ptrainer { get; set; }
        public string especialidade { get; set; }
        public Nullable<int> xp { get; set; }
        public Nullable<System.DateTime> idade { get; set; }
        public Nullable<decimal> phora { get; set; }
    
        public virtual especialidades especialidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservas> reservas { get; set; }
    }
}
