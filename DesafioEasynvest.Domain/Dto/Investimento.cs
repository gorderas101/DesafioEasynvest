using DesafioEasynvest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Dto
{
    public class Investimento
    {
        
        public string Nome { get; set; }
        public decimal ValorInvestimento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Ir { get; set; }
        public decimal ValorResgate { get; set; }

    }
}
