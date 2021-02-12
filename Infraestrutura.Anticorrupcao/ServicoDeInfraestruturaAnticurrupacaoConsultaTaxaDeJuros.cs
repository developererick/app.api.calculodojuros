using Dominio.Entidades;
using Interfaces.Infraestrutura;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infraestrutura.Anticorrupcao
{
    public class ServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros : IServicoDeInfraestruturaAnticurrupacaoConsultaTaxaDeJuros
    {

        private HttpClient CriarClient(ParametrosAPIConsultaTaxaDeJuros parametros)
        {
            parametros.urlApi = parametros.urlApi.EndsWith("/") ? parametros.urlApi : parametros.urlApi + "/";

            var client = new HttpClient()
            {
                BaseAddress = new Uri(parametros.urlApi),
                Timeout = TimeSpan.FromMilliseconds(864000000)
            };
            return client;
        }

        public decimal ConsultarTaxaDeJuros(ParametrosAPIConsultaTaxaDeJuros parametros)
        {
            decimal resultado;

            try
            {
                using (var client = CriarClient(parametros))
                {
                    using (var response = client.GetAsync(parametros.urlApi).Result)
                    {
                        resultado = JsonConvert.DeserializeObject<decimal>(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
    }
}
