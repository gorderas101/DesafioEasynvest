using DesafioEasynvest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Interfaces.Service
{
    public interface IEasynvestaService
    {
        Contrato GetContrato(DateTime dataResgate);
    }
}
