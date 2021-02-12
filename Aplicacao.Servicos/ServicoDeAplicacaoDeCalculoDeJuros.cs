using Dominio.Servicos;
using Interfaces.Aplicacao;
using Interfaces.Dominio;

namespace Aplicacao.Servicos
{
    public class ServicoDeAplicacaoDeCalculoDeJuros : IServicoDeAplicacaoDeCalculoDeJuros
    {
        private readonly IServicoDeDominioDeCalculoDeJuros _servicoDeDominioDeCalculoDeJuros;
        public ServicoDeAplicacaoDeCalculoDeJuros(IServicoDeDominioDeCalculoDeJuros servicoDeDominioDeCalculoDeJuros)
        {
            _servicoDeDominioDeCalculoDeJuros = servicoDeDominioDeCalculoDeJuros;
        }

        public decimal CalcularJurosComposto(decimal valorInicial, int tempoEmMeses)
        {
            return _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(valorInicial, tempoEmMeses);
        }
    }
}
