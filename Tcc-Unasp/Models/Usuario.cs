//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tcc_Unasp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Atendimento = new HashSet<Atendimento>();
            this.Reuniao = new HashSet<Reuniao>();
        }
    
        public int IdUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public Nullable<System.DateTime> dataDeCadastro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atendimento> Atendimento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reuniao> Reuniao { get; set; }
    }
}
