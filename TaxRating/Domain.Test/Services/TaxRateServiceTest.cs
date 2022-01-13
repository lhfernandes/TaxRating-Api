using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.ExternalService;
using Domain.Interfaces.Services;
using Domain.Services;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Test.Services
{
    public class TaxRateServiceTest
    {
        [Theory]
        [InlineData("BRL", 5.572907)]
        [InlineData("USD",1.00)]
        [InlineData("CAD", 1.257339)]
        public async Task GetTaxRateByRatePrefixExpectTrueAsync(string rate,double val)
        {
            var mock = new Mock<ITaxRateServiceApi>();
            var service = new TaxRateService(new Mock<INotificator>().Object, mock.Object);
            
            Task<ApiResponse<TaxRate>> result = service.GetTaxRateByPrefix(rate);

            // Assert           
            await Task.Run(() => result.Result.Should().BeOfType<ApiResponse<TaxRate>>().Which.Data.Should().NotBeNull());
            await Task.Run(() => result.Result.Should().BeOfType<ApiResponse<TaxRate>>().Which.Message.Should().NotBeNullOrEmpty());
            await Task.Run(() => result.Result.Should().BeOfType<ApiResponse<TaxRate>>().Which.Notifications.Should().BeNullOrEmpty());
            await Task.Run(() => result.Result.Should().BeOfType<ApiResponse<TaxRate>>().Which.Data.ValueRate.Should().Be(val));

        }
    }
}
