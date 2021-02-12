using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Dominio
{
    public interface IServicoDeDominioDeCalculoDeJuros
    {
        decimal CalcularJurosComposto(decimal valorInicial, int tempoEmMeses);
    }
}
