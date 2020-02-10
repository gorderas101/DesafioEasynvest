using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Entity
{
    public class RendaFixaEntity
    {
        public RendaFixaEntity()
        {
            this.Lcis = new List<RendaFixaItens>();
        }
        public IEnumerable<RendaFixaItens> Lcis { get; set; }
        
    }
}
