
using DesafioEasynvest.Data.Repositories;
using DesafioEasynvest.Domain.Interfaces.Gateway;
using DesafioEasynvest.Domain.Interfaces.Repositories;
using DesafioEasynvest.Domain.Interfaces.Service;
using DesafioEasynvest.Gateway;
using DesafioEasynvest.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.CrossCutting.WebHelper
{
    public class RegistraDependencia
    {
        public static void Registrar(IServiceCollection services)
        {
            //Gateway
            services.AddTransient<IEasynvestaGateway, EasynvestaGateway>();

            //Service
            services.AddTransient<IEasynvestaService, EasynvestaService>();

            //Repository
            services.AddTransient<IContratoRepository, ContratoRepository>();

            


        }

    }
}
