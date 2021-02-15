using Dominio.Entidades;
using Interfaces.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.Servicos
{
    public class ServicoDeInfraestruturaDeConfiguracoes : IServicoDeInfraestruturaDeConfiguracoes
    {

        private readonly AppSettings _appSettings;

        public ServicoDeInfraestruturaDeConfiguracoes(AppSettings appSettings)
        {
            this._appSettings = appSettings;
        }

        public ServicoDeInfraestruturaDeConfiguracoes()
        {
            //adicionado para possibilitar a execução através do projeto de teste
            //a aplicação publicada irá realizar a leitura da url a partir do appsettings.json
            this._appSettings = new AppSettings { UrlApiTaxaDeJuros = "http://localhost:55425/api/v1/juros/taxajuros" };
        }

        public string RecuperarUrlApiConsultaTaxaDeJuros()
        {
            string url = _appSettings.UrlApiTaxaDeJuros;
            return url.Trim();
        }

        public string RecuperarUrlApiTaxaDeJurosGitHub()
        {
            string url = _appSettings.UrlApiTaxaDeJurosGitHub;
            return url.Trim();
        }

        public string RecuperarUrlApiCalculoDeJurosGitHub()
        {
            string url = _appSettings.UrlApiCalculoDeJurosGitHub;
            return url.Trim();
        }
    }
}
