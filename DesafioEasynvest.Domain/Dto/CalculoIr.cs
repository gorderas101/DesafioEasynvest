using DesafioEasynvest.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Dto
{
    public class CalculoIr
    {
        public TipoInvestimento TipoInvestimento { get; set; }

        public decimal Valor { get; set; }


    }
}
