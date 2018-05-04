using Nfe.StateTax.Domain;
using System;
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
            Assert.Contains("<h3 class=\"panel-title\">Cadastro de Contribuinte Nacional</h3>", result);
        }
    }

}
