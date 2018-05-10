using Nfe.StateTax.Domain;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Nfe.Tests
{
    public class StateTaxScrapTests
    {
        [Fact]
        public async Task PreScrap_WhenDataIsValid_ReturnsOK()
        {
            // Arrange
            var httpClient = new HttpClient();
            var scrap = new StateTaxScrap(httpClient);

            // Act
            var result = await scrap.PreScrap();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("<h3 class=\"panel-title\">Cadastro de Contribuinte Nacional</h3>", result);
        }

        [Fact]
        public async Task Scrap_WhenDataIsValid_ReturnsOK()
        {
            // Arrange
            var httpClient = new HttpClient();
            var scrap = new StateTaxScrap(httpClient);
            var cnpj = 08765239000164;

            // Act
            var result = await scrap.Scrap(cnpj);

            // Assert
            Assert.NotNull(result);
            //Assert.Contains("<h3 class=\"panel-title\">Cadastro de Contribuinte Nacional</h3>", result);
        }

        [Fact]
        public async Task Scrap_WhenHttpResponseIsNotOK_ReturnsNull()
        {
            // Arrange
            var httpClient = new HttpClient();
            var scrap = new StateTaxScrap(httpClient);
            var cnpj = 08765239000164;

            // Act
            var result = await scrap.Scrap(cnpj);

            // Assert
            Assert.Null(result);
            //Assert.Contains("<h3 class=\"panel-title\">Cadastro de Contribuinte Nacional</h3>", result);
        }

        [Fact]
        public async Task ReadScrap_WhenDataIsValid_ReturnsTheCorrectObject()
        {
            // Arrange
            var scrap = new StateTaxScrap();
            var html = File.ReadAllText(@"z:\Users\staff\Documents\studies\Nfe.StateTax\test\Nfe.Tests\mockHtml.html");
            var expectObject = new InfoCnpj
            {
                NumeroIncricao = 142718026110,
                SituacaoCadastral = "Habilitado",
                UfOrigem = "SP",
                FederalNumber = 08765239000164,
                NomeFantasia = "",
                NomeEmpresarial = "TECHCRED COMERCIO E SERVICOS LTDA  - ME"
            };

            // Act
            var result = await scrap.ReadScrap(html);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectObject, result);
        }
    }

}
