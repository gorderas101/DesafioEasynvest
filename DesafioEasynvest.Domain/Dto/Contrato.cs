using DesafioEasynvest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioEasynvest.Domain.Dto
{
    public class Contrato
    {
        public Contrato()
        {
            this.Investimenos = new List<Investimento>();
        }
        public Contrato(List<FundosItens> fundos, List<RendaFixaItens> rendaFixas, List<TesouroDiretoItens> tesouroDiretos, List<CalculoIr> calculos, DateTime dataResgate)
        {
            this.Investimenos = new List<Investimento>();
            
            this.ValorTotal = fundos.Sum(x=> x.ValorAtual) + rendaFixas.Sum(x=> x.CapitalAtual) + tesouroDiretos.Sum(x=> x.ValorTotal);

            if (fundos.Count > 0)
                this.CarregaFundos(fundos, calculos.FirstOrDefault(x=> x.TipoInvestimento == Enum.TipoInvestimento.Fundos).Valor, dataResgate);
            
            if(rendaFixas.Count > 0)
                this.CarregaRendaFixa(rendaFixas, calculos.FirstOrDefault(x => x.TipoInvestimento == Enum.TipoInvestimento.RendaFixa).Valor, dataResgate);
            
            if (tesouroDiretos.Count > 0)
                this.CarregaTesouroDireto(tesouroDiretos, calculos.FirstOrDefault(x => x.TipoInvestimento == Enum.TipoInvestimento.TesouroDireto).Valor, dataResgate);
            
        }

        public decimal ValorTotal { get; set; }
        

        public List<Investimento> Investimenos { get; set; }

        private void CarregaFundos(List<FundosItens> fundos, decimal percentualIr, DateTime dataResgate)
        {
            fundos.ForEach(x=> this.Investimenos.Add(new Investimento { 
                Nome = x.Nome,
                ValorInvestimento = x.CapitalInvestido,
                ValorTotal = x.ValorAtual,
                ValorResgate = CalculaResgate(x.DataCompra, x.DataResgate, dataResgate, x.ValorAtual),
                Vencimento = x.DataResgate,
                Ir = (x.ValorAtual * percentualIr) / 100
            }));
        }

        private void CarregaRendaFixa(List<RendaFixaItens> rendaFixas, decimal percentualIr, DateTime dataRestate)
        {
            rendaFixas.ForEach(x => this.Investimenos.Add(new Investimento
            {
                Nome = x.Nome,
                ValorInvestimento = x.CapitalInvestido,
                ValorTotal = x.CapitalAtual,
                ValorResgate = CalculaResgate(x.DataOperacao, x.Vencimento, DateTime.Now, x.CapitalAtual),
                Vencimento = x.Vencimento,
                Ir = (x.CapitalAtual * percentualIr) / 100
            }));
        }

        private void CarregaTesouroDireto(List<TesouroDiretoItens> rendaFixas, decimal percentualIr, DateTime dataResgate)
        {
            rendaFixas.ForEach(x => this.Investimenos.Add(new Investimento
            {
                Nome = x.Nome,
                ValorInvestimento = x.ValorInvestido,
                ValorTotal = x.ValorTotal,
                ValorResgate = CalculaResgate(x.DataDeCompra, x.Vencimento, dataResgate, x.ValorTotal),
                Vencimento = x.Vencimento,
                Ir = (x.ValorTotal * percentualIr) / 100
            }));
        }

        private decimal CalculaResgate(DateTime dataDeCompra, DateTime dataVencimento, DateTime dataRestate, decimal valorTotal)
        {

           
            var difCompraVencimento = CrossCutting.Helper.Util.DataDiff('m', dataVencimento, dataDeCompra);
            var difCompraResgate = CrossCutting.Helper.Util.DataDiff('m', dataDeCompra, dataRestate);

            var difVencimentoResgate = difCompraVencimento - difCompraResgate;

           
            if (difVencimentoResgate <= 3)
                return valorTotal - ((valorTotal * 6) / 100);


            if(difVencimentoResgate < (difCompraVencimento / 2))
                return valorTotal - ((valorTotal * 15) / 100);

            return valorTotal - ((valorTotal * 30) / 100);


        }

    }
}
