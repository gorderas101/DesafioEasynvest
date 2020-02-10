using DesafioEasynvest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Interfaces.Repositories
{
    public interface IContratoRepository
    {
        Contrato GetContrato();
        void SetContrato(Contrato contrato);
    }
}
