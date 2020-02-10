using DesafioEasynvest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Interfaces.Gateway
{
    public interface IEasynvestaGateway
    {
        IEnumerable<FundosItens> GetFundos();
        IEnumerable<RendaFixaItens> GetRendaFixa();
        IEnumerable<TesouroDiretoItens> GetTesouroDireto();
    }
}
