//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tcc_Unasp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoNegociacao
    {
        public TipoNegociacao()
        {
            this.Negociacao = new HashSet<Negociacao>();
        }
    
        public int IdTipoNegociacao { get; set; }
        public string Descricao { get; set; }
    
        public virtual ICollection<Negociacao> Negociacao { get; set; }
    }
}
