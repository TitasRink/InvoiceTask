using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

namespace InvoiceTask.xUniTests
{
    public class InvoiceTests
    {
        //VAT Africa = 20;
        //VAT Antarctic = 15;
        //VAT Asia = 10;
        //VAT CentralAmerica = 30;

        ClientModel client;
        SellerModel seller;

        ICalculateVatServices vatServices = new CalculateVatServices();
        ICountryServices countryServices = new CountryServices();

        // TASK 1
        [Fact]
        public async void When_SellerVatIsFalse_ReturnZero()
        {
            client = new() { ClientRegion = "Europe", ClientIsVatPayer = true };
            seller = new() { Region = "Antarctic", IsVat = false};

            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            Assert.Equal(0, result);
        }

        // TASK 2
        [Fact]
        public async void When_ClientNotFromEurope_ReturnZero()
        {
            client = new() { ClientRegion = "Asia" };
            seller = new(){ Region = "Europe" };

            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            Assert.Equal(0, result);
        }

        // TASK 3
        [Fact]
        public async void When_ClientAndSellerNotFromSameRegion_ReturnSellerRegionVat()
        {
            client = new() { ClientRegion = "Europe" };
            seller = new() { Region = "Asia" };

            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            Assert.Equal(10, result);
        }

        // TASK 4
        [Fact]
        public async void When_ClientAndSellerFromSameRegion_ReturnRegionVat()
        {
            client = new() { ClientRegion = "Central America" };
            seller = new() { Region = "Central America" };

            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            Assert.Equal(30, result);
        }
    }
}