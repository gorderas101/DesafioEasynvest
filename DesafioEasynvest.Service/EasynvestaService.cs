using DesafioEasynvest.Domain.Dto;
using DesafioEasynvest.Domain.Interfaces.Gateway;
using DesafioEasynvest.Domain.Interfaces.Repositories;
using DesafioEasynvest.Domain.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioEasynvest.Service
{
    public class EasynvestaService : IEasynvestaService
    {
        private readonly IEasynvestaGateway _easynvestaGateway;
        private readonly IContratoRepository _contratoRepository;
        private readonly IConfiguration _configuration;
        public EasynvestaService(IEasynvestaGateway easynvestaGateway, IContratoRepository contratoRepository, IConfiguration configuration)
        {
            this._easynvestaGateway = easynvestaGateway;
            this._contratoRepository = contratoRepository;
            this._configuration = configuration;
        }
        public Contrato GetContrato(DateTime dataResgate)
        {
            var contrato = this._contratoRepository.GetContrato();

            if (contrato != null)
                return contrato;

           
            var fundos = _easynvestaGateway.GetFundos().ToList();
            var rendaFixa = _easynvestaGateway.GetRendaFixa().ToList();
            var tesouroDireto = _easynvestaGateway.GetTesouroDireto().ToList();

            var calculos = this.ConfiguraValoresIr();

            contrato = new Contrato(fundos, rendaFixa, tesouroDireto, calculos, dataResgate);


            this._contratoRepository.SetContrato(contrato);

            return contrato;
        }

        private List<CalculoIr> ConfiguraValoresIr ()
        {
            var result = new List<CalculoIr>();

            result.Add(new CalculoIr
            {
                TipoInvestimento = Domain.Enum.TipoInvestimento.Fundos,
                Valor = decimal.Parse(this._configuration.GetSection("PercIrFundos").Value)
            });

            result.Add(new CalculoIr
            {
                TipoInvestimento = Domain.Enum.TipoInvestimento.RendaFixa,
                Valor = decimal.Parse(this._configuration.GetSection("PercIrRendaFixa").Value)
            });

            result.Add(new CalculoIr
            {
                TipoInvestimento = Domain.Enum.TipoInvestimento.TesouroDireto,
                Valor = decimal.Parse(this._configuration.GetSection("PercIrTesouroDireto").Value)
            });

            return result;

        }

        
    }
}
