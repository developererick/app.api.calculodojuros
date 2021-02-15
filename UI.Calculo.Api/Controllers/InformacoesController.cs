using Interfaces.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Calculo.Api.Controllers
{ 

    [Route("api/v1/informacoes")]
    public class InformacoesController : Controller
    {
        private readonly IServicoDeAplicacaoDeConsultaDeInformacoesDoSistema _servicoDeAplicacaoDeConsultaDeInformacoesDoSistema;
        
        public InformacoesController(IServicoDeAplicacaoDeConsultaDeInformacoesDoSistema servicoDeAplicacaoDeConsultaDeInformacoesDoSistema)
        {
            this._servicoDeAplicacaoDeConsultaDeInformacoesDoSistema = servicoDeAplicacaoDeConsultaDeInformacoesDoSistema;
        }

        [HttpGet("/showmethecode")]
        public IActionResult RetornarUrlsGitHub()
        {
            var listaUrlsGitHub = _servicoDeAplicacaoDeConsultaDeInformacoesDoSistema.RetornarUrlsGitHub();
            return Ok(listaUrlsGitHub);
        }
    }
}
