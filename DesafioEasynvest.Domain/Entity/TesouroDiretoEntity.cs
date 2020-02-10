using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Entity
{
    public class TesouroDiretoEntity
    {
        public TesouroDiretoEntity()
        {
            this.Tds = new List<TesouroDiretoItens>();
        }
        public IEnumerable<TesouroDiretoItens> Tds { get; set; }
       
    }
}
