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
    
    public partial class Pagamento
    {
        public int IdPagamento { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public Nullable<int> nParcela { get; set; }
        public Nullable<double> Valor { get; set; }
        public int IdTipoPagamento { get; set; }
        public Nullable<int> IdNegociacao { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Negociacao Negociacao { get; set; }
        public virtual tblStatus tblStatus { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
    }
}
