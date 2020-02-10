using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Entity
{
    public class TesouroDiretoItens
    {
       
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataDeCompra { get; set; }
        public decimal Iof { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }

    }
}
