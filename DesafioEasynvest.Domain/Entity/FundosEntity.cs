using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Entity
{
    public class FundosEntity
    {
        public FundosEntity()
        {
            Fundos = new List<FundosItens>();
        }
        public IEnumerable<FundosItens> Fundos { get; set; }

    }
}
