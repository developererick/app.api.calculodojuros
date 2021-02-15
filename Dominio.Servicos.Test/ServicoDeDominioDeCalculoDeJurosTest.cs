using Interfaces.Dominio;
using Dominio.Servicos;
using Xunit;
using System;

namespace Dominio.Servicos.Test
{
    public class ServicoDeDominioDeCalculoDeJurosTest
    {
        private readonly IServicoDeDominioDeCalculoDeJuros _servicoDeDominioDeCalculoDeJuros;
        public ServicoDeDominioDeCalculoDeJurosTest()
        {
            _servicoDeDominioDeCalculoDeJuros = new ServicoDeDominioDeCalculoDeJuros();
        }

        [Fact]
        public void CalcularJuros_Parametro_valorInicial_Negativo()
        {
            var jurosCalculado = _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(-1, 5);
            Assert.IsType<ArgumentException>(jurosCalculado);
        }

        [Fact]
        public void CalcularJuros_Parametro_valorInicial_Zerado()
        {
            var jurosCalculado = _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(0, 5);
            Assert.IsType<ArgumentException>(jurosCalculado);
        }

        [Fact]
        public void CalcularJuros_Parametro_tempoEmMeses_Negativo()
        {
            var jurosCalculado = _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(100, -5);
            Assert.IsType<ArgumentException>(jurosCalculado);
        }

        [Fact]
        public void CalcularJuros_Parametro_tempoEmMeses_Zerado()
        {
            var jurosCalculado = _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(100, 0);
            Assert.IsType<ArgumentException>(jurosCalculado);
        }

        [Fact]    
        public void CalcularJuros_Valor_Juros_Valido()
        {
            decimal juros = 105.10M;
            var jurosCalculado = _servicoDeDominioDeCalculoDeJuros.CalcularJurosComposto(100, 5);
            Assert.Equal(juros, jurosCalculado);
        }
    }
}
