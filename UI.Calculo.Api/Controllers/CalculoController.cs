using Interfaces.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Calculo.Api.Controllers
{
    [Route("api/v1/calculo")]
    public class CalculoController : ControllerBase
    {

        private readonly IServicoDeAplicacaoDeCalculoDeJuros _servicoDeAplicacaoDeCalculoDeJuros;
        public CalculoController(IServicoDeAplicacaoDeCalculoDeJuros servicoDeAplicacaoDeCalculoDeJuros)
        {
            this._servicoDeAplicacaoDeCalculoDeJuros = servicoDeAplicacaoDeCalculoDeJuros;
        }

        [HttpGet("calculajuros")]
        public IActionResult GetCalculaJuros(decimal valorInicial, int tempoEmMeses)
        {
            var valorJuros = _servicoDeAplicacaoDeCalculoDeJuros.CalcularJurosComposto(valorInicial, tempoEmMeses);
            return Ok(valorJuros);
        }
    }
}
