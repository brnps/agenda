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
    using System.ComponentModel.DataAnnotations;

    public partial class ContatoTelEmail
    {
        [Key]
        public int Id { get; set; }
        public int Id_Contato { get; set; }
        public Nullable<int> Telefone { get; set; }
        public string Email { get; set; }
    
        public virtual Contato Contato { get; set; }
    }
}
