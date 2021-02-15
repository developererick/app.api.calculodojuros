using Dominio.Servicos;
using Interfaces.Dominio;
using Microsoft.Extensions.DependencyInjection;


namespace Infraestrutura.IoC
{
    public static class ModuloDominioIoC
    {
        public static void AddServicosDeDominio(this IServiceCollection services)
        {
            services.AddScoped<IServicoDeDominioDeCalculoDeJuros, ServicoDeDominioDeCalculoDeJuros>();
            services.AddScoped<IServicoDeDominioDeConsultaDeInformacoesDoSistema, ServicoDeDominioDeConsultaDeInformacoesDoSistema>();
        }
    }
}
