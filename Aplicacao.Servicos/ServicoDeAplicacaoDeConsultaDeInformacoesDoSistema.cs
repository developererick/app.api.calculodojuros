using Interfaces.Aplicacao;
using Interfaces.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Servicos
{
    public class ServicoDeAplicacaoDeConsultaDeInformacoesDoSistema : IServicoDeAplicacaoDeConsultaDeInformacoesDoSistema
    {
        private readonly IServicoDeDominioDeConsultaDeInformacoesDoSistema _servicoDeDominioDeConsultaDeInformacoesDoSistema;
        public ServicoDeAplicacaoDeConsultaDeInformacoesDoSistema(IServicoDeDominioDeConsultaDeInformacoesDoSistema servicoDeDominioDeConsultaDeInformacoesDoSistema)
        {
            this._servicoDeDominioDeConsultaDeInformacoesDoSistema = servicoDeDominioDeConsultaDeInformacoesDoSistema;
        }

        public List<string> RetornarUrlsGitHub()
        {
            return _servicoDeDominioDeConsultaDeInformacoesDoSistema.RetornarUrlsGitHub();
        }
    }
}
