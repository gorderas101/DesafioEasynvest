using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Entity
{
    public class RendaFixaItens
    {
        
        public decimal CapitalInvestido { get; set; }
        public decimal CapitalAtual { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Iof { get; set; }
        public decimal OutrasTaxas { get; set; }
        public decimal Taxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GarantiaFgc { get; set; }
        public DateTime DataOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Primeiro { get; set; }
    }
}
