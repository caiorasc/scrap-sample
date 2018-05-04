using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nfe.StateTax.Domain
{
    public class StateTaxScrap : IScrap
    {
        private HttpClient _httpClient;
        public StateTaxScrap(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<string> PreScrap()
        {
            // monstar header

            // mandar a request
            var response = await _httpClient.GetStringAsync("http://www.sefaz.go.gov.br/ccn/");

            return response;
            // pegar a resposta e ler
        }

        public async Task<string> Scrap(long cnpj)
        {
            throw new NotImplementedException();
        }
    }
}
