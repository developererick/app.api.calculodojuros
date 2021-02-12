using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Infraestrutura
{
    public interface IServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros
    {
        decimal ConsultarTaxaDeJuros(ParametrosAPIConsultaTaxaDeJuros parametros);
    }
}
