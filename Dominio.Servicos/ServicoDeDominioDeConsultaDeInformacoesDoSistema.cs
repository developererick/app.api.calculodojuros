using Interfaces.Dominio;
using Interfaces.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoDeDominioDeConsultaDeInformacoesDoSistema : IServicoDeDominioDeConsultaDeInformacoesDoSistema
    {
        private readonly IServicoDeInfraestruturaDeConfiguracoes _servicoDeInfraestruturaDeConfiguracoes;
        public ServicoDeDominioDeConsultaDeInformacoesDoSistema(IServicoDeInfraestruturaDeConfiguracoes servicoDeInfraestruturaDeConfiguracoes)
        {
            this._servicoDeInfraestruturaDeConfiguracoes = servicoDeInfraestruturaDeConfiguracoes;
        }
        
        public List<string> RetornarUrlsGitHub()
        {
            var listaUrlsGitHub = new List<string>();
            var urlGitHubApiTaxaDeJuros = _servicoDeInfraestruturaDeConfiguracoes.RecuperarUrlApiTaxaDeJurosGitHub();
            var urlGitHubApiCalculoDeJuros = _servicoDeInfraestruturaDeConfiguracoes.RecuperarUrlApiCalculoDeJurosGitHub();
            listaUrlsGitHub.Add(urlGitHubApiTaxaDeJuros);
            listaUrlsGitHub.Add(urlGitHubApiCalculoDeJuros);
            return listaUrlsGitHub;
        }
    }
}
