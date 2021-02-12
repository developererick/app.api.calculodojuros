using Dominio.Entidades;
using Interfaces.Dominio;
using Interfaces.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoDeDominioDeCalculoDeJuros : IServicoDeDominioDeCalculoDeJuros
    {
        private readonly IServicoDeInfraestruturaDeConfiguracoes _servicoDeInfraestruturaDeConfiguracoes;
        private readonly IServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros _servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros;
        public ServicoDeDominioDeCalculoDeJuros(IServicoDeInfraestruturaDeConfiguracoes servicoDeInfraestruturaDeConfiguracoes,
            IServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros)
        {
            this._servicoDeInfraestruturaDeConfiguracoes = servicoDeInfraestruturaDeConfiguracoes;
            this._servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros = servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros;
        }
        public decimal CalcularJurosComposto(decimal valorInicial, int tempoEmMeses)
        {
            if(valorInicial<=0.00M)
                throw new ArgumentException("O valor inicial não pode ser maior que zero.");
            if (tempoEmMeses < 1)
                throw new ArgumentException("O tempo em meses deve ser maior ou igual a um.");

            var urlApiConsultaTaxaDeJuros = _servicoDeInfraestruturaDeConfiguracoes.RecuperarUrl();
            if (String.IsNullOrEmpty(urlApiConsultaTaxaDeJuros))
                throw new ArgumentNullException("A URL de acesso da API de Consulta de Taxa de Juros não foi preenchida");

            var parametrosDeAcessoApiConsultaTaxaDeJuros = new ParametrosAPIConsultaTaxaDeJuros
            {
                urlApi = urlApiConsultaTaxaDeJuros
            };

            var taxaDeJuros = _servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros.ConsultarTaxaDeJuros(parametrosDeAcessoApiConsultaTaxaDeJuros);

            var taxaDeJurosDouble = Convert.ToDouble(taxaDeJuros);
            var valorInicialDouble = Convert.ToDouble(valorInicial);
            var valorJuros = Convert.ToDecimal(Math.Round(valorInicialDouble * Math.Pow(1.0 + taxaDeJurosDouble, tempoEmMeses),2));

            return (valorJuros);
        }
    }
}
