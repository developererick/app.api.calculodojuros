using Infraestrutura.Anticorrupcao;
using Infraestrutura.Servicos;
using Interfaces.Infraestrutura;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.IoC
{
    public static class ModuloInfraestruturaIoC
    {
        public static void AddServicosDeInfraestrutura(this IServiceCollection services)
        {
            services.AddScoped<IServicoDeInfraestruturaDeConfiguracoes, ServicoDeInfraestruturaDeConfiguracoes>();
            services.AddScoped<IServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros, ServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros>();
        }

    }
}
