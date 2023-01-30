using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

namespace InvoiceTask.xUniTests
{
    public class InvoiceTests
    {
        ClientModel clientEurope = new() { ClientRegion = "Europe" , ClientIsVatPayer = true};
        SellerModel selleAsia = new SellerModel { Region = "Asia" };

        CalculateVatServices vatServices = new CalculateVatServices();
        ICountryServices countryServices = new CountryServices();

        double rr;
        public async Task InitializeAsync()
        {
            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(clientEurope, selleAsia));
            var rr = Convert.ToInt32(result);

        }
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async void Test1()
        {
    

            Assert.Equal(20, rr);
        }
    }
}