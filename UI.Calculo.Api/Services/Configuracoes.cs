using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Calculo.Api.Services
{
    public static class Configuracoes
    {
        public static void AddConfiguracoes(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("AppSettings").Get<AppSettings>();
        }
    }
}
