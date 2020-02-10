using DesafioEasynvest.Domain.Dto;
using DesafioEasynvest.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.Data.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly IDistributedCache _cache;
        private const string KEY = "CONTR_INVEST";

        public ContratoRepository(IDistributedCache cache)
        {
            this._cache = cache;
        }
        public Contrato GetContrato()
        {
            var dataCache = _cache.GetStringAsync(KEY).Result;

           
            if (!string.IsNullOrWhiteSpace(dataCache))
            {
                return  JsonConvert.DeserializeObject<Contrato>(dataCache);
            }

            return null;

        }

        public void SetContrato(Contrato contrato)
        {

            var dataCache = _cache.GetStringAsync(KEY).Result;

            var cacheSettings = new DistributedCacheEntryOptions();
            cacheSettings.SetAbsoluteExpiration(TimeSpan.FromDays(1));
           
            var itemsJson = JsonConvert.SerializeObject(contrato);

            _cache.SetStringAsync(KEY, itemsJson, cacheSettings);
        }
    }
}
