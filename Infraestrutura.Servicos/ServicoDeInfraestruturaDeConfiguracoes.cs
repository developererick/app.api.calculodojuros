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

        public AppSettings ConfiguracoesAmbiente()
        {
            return _appSettings;
        }

        public string RecuperarUrl()
        {
            string url = _appSettings.TaxaDeJurosAPIUrl;
            return url.Trim();
        }
    }
}
