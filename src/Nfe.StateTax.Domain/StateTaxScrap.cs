using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nfe.StateTax.Domain
{
    public class StateTaxScrap : IScrap
    {
        private HttpClient _httpClient;
        public StateTaxScrap(HttpClient httpClient = null) 
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<string> PreScrap()
        {
            // monstar header

            // mandar a request
            var response = await _httpClient.GetStringAsync("http://www.sefaz.go.gov.br/ccn/");

            return response;
            // pegar a resposta e ler
        }

        public async Task<InfoCnpj> Scrap(long cnpj)
        {
            var test = $"tipoDocumento=cnpj&numrDocumento=0{cnpj}&btnSubmit=";


            var content = new StringContent(test, Encoding.UTF8, "application/x-www-form-urlencoded");
            var infoCnpj = new InfoCnpj();
            var post = await _httpClient.PostAsync("http://www.sefaz.go.gov.br/ccn/001lstResultado.asp", content);

            if (post.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var htmlResponse = await post.Content.ReadAsStringAsync();

            return infoCnpj;
        }

        public async Task<InfoCnpj> ReadScrap(string html)
        {
            var tableStartIndex = html.IndexOf("<table");
            var tableEndIndex = html.IndexOf("</table>");
            var tableLength = (tableEndIndex + 8) - tableStartIndex;
            var table = html.Substring(tableStartIndex, tableLength);

            //var tableSplit = table.Split(" ");



            var infoCnpj = new InfoCnpj();


            return infoCnpj;
        }
    }
}
