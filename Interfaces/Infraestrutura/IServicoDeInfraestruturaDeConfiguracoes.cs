using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Infraestrutura
{
    public interface IServicoDeInfraestruturaDeConfiguracoes
    {
        string RecuperarUrlApiConsultaTaxaDeJuros();
        string RecuperarUrlApiTaxaDeJurosGitHub();
        string RecuperarUrlApiCalculoDeJurosGitHub();
    }
}
