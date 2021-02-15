using Microsoft.Extensions.DependencyInjection;
using Aplicacao.Servicos;
using Interfaces.Aplicacao;

namespace Infraestrutura.IoC
{
    public static class ModuloAplicacaoIoC
    {
        public static void AddServicosDeAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IServicoDeAplicacaoDeCalculoDeJuros, ServicoDeAplicacaoDeCalculoDeJuros>();
            services.AddScoped<IServicoDeAplicacaoDeConsultaDeInformacoesDoSistema, ServicoDeAplicacaoDeConsultaDeInformacoesDoSistema>();
        }
    }
}
