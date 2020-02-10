using DesafioEasynvest.Domain.Entity;
using DesafioEasynvest.Domain.Interfaces.Gateway;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DesafioEasynvest.Gateway
{
    public class EasynvestaGateway : IEasynvestaGateway
    {
        private string _url;
        public EasynvestaGateway(IConfiguration configuration)
        {

            this._url = configuration.GetSection("UrlApi").Value;

        }
        public IEnumerable<FundosItens> GetFundos()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               

                var response = client.GetAsync("v2/5e342ab33000008c00d96342").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<FundosEntity>(json);

                   return result.Fundos;

                }

                return new List<FundosItens>();
                

            }
                
        }

        public IEnumerable<RendaFixaItens> GetRendaFixa()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("v2/5e3429a33000008c00d96336").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<RendaFixaEntity>(json);

                    return result.Lcis;

                }

                return new List<RendaFixaItens>();


            }
        }

        public IEnumerable<TesouroDiretoItens> GetTesouroDireto()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("v2/5e3428203000006b00d9632a").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<TesouroDiretoEntity>(json);
                        
                    return result.Tds;

                }

                return new List<TesouroDiretoItens>();


            }
        }
    }
}
