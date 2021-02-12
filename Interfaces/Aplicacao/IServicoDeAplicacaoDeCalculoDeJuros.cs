using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Aplicacao
{
    public interface IServicoDeAplicacaoDeCalculoDeJuros
    {
        decimal CalcularJurosComposto(decimal valorInicial, int tempoEmMeses);
    }
}
