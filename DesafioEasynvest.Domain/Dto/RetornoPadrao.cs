using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Domain.Dto
{
    public class RetornoPadrao
    {
        public RetornoPadrao(Contrato contrato)
        {
            this.Sucesso = true;
            this.Erros = new List<string>();

            if (contrato.Investimenos.Count == 0)
            {
                this.Sucesso = false;
                this.Erros.Add("Não Foram Encontrados Investimentos");
            }
            
            this.Retorno = contrato;
        }

        public RetornoPadrao(List<string> erros)
        {
            this.Sucesso = false;
            this.Erros = erros;

        }
        

        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public object Retorno { get; set; }
    }
}
