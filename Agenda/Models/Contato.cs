//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agenda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contato()
        {
            this.ContatoTelEmail = new HashSet<ContatoTelEmail>();
        }
    
        public int Id_Contato { get; set; }
        public string Nome_Contato { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoTelEmail> ContatoTelEmail { get; set; }
    }
}
