using DesafioEasynvest.API.Controllers;
using DesafioEasynvest.Data.Repositories;
using DesafioEasynvest.Domain.Dto;
using DesafioEasynvest.Domain.Interfaces.Gateway;
using DesafioEasynvest.Domain.Interfaces.Repositories;
using DesafioEasynvest.Domain.Interfaces.Service;
using DesafioEasynvest.Gateway;
using DesafioEasynvest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace DesafioEasynvest.Test
{
    public class Teste
    {


        private IEasynvestaService service;
        private IEasynvestaGateway gateway;
        private IConfiguration configuration;
        private IContratoRepository contratoRepository;
        private IDistributedCache cache;

        [SetUp]
        public void Setup()
        {



            var services = new ServiceCollection();
            var redisconnection = "127.0.0.1:6379,DefaultDatabase=1";
            
            services.AddDistributedRedisCache(o => { o.Configuration = redisconnection; });

            var provider = services.BuildServiceProvider();
            cache = provider.GetService<IDistributedCache>();


            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            configuration = configurationBuilder.Build();



            contratoRepository = new ContratoRepository(cache);
            gateway = new EasynvestaGateway(configuration);

            

            service = new EasynvestaService(gateway, contratoRepository, configuration);
        }



        [Test]
        public void ValidaRetornoContratos()
        {

            ContratoController controller = new ContratoController(service);

            var result = service.GetContrato(DateTime.Now);

            Assert.IsInstanceOf(typeof(Contrato), result);
            Assert.NotZero(result.Investimenos.Count);
        }
    }
}