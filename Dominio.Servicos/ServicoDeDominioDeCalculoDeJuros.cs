using Dominio.Entidades;
using Infraestrutura.Anticorrupcao;
using Infraestrutura.Servicos;
using Interfaces.Dominio;
using Interfaces.Infraestrutura;
using System;

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
        public ServicoDeDominioDeCalculoDeJuros()
        {
            this._servicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros = new ServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros();
            this._servicoDeInfraestruturaDeConfiguracoes = new ServicoDeInfraestruturaDeConfiguracoes();
        }
        public decimal CalcularJurosComposto(decimal valorInicial, int tempoEmMeses)
        {
            if(valorInicial<=0.00M)
                throw new ArgumentException("O valor inicial não pode ser menor que zero.");
            if (tempoEmMeses < 1)
                throw new ArgumentException("O tempo em meses deve ser maior ou igual a um.");

            var urlApiConsultaTaxaDeJuros = _servicoDeInfraestruturaDeConfiguracoes.RecuperarUrlApiConsultaTaxaDeJuros();
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
