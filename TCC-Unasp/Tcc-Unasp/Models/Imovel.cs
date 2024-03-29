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
    
    public partial class Imovel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imovel()
        {
            this.ImovelTerceiro = new HashSet<ImovelTerceiro>();
            this.Loteamento = new HashSet<Loteamento>();
            this.Reuniao = new HashSet<Reuniao>();
        }
    
        public int IdImovel { get; set; }
        public int IdEndereco { get; set; }
        public int NImovel { get; set; }
        public int TipoImovel { get; set; }
        public string StatusImovel { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public float VlrImovel { get; set; }

        public virtual tblLogradouros tblLogradouros { get; set; }
        public virtual TipoImovel TipoImovel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImovelTerceiro> ImovelTerceiro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loteamento> Loteamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reuniao> Reuniao { get; set; }
    }
}
