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

        ICalculateVatServices vatServices = new CalculateVatServices();
        ICountryServices countryServices = new CountryServices();

        ClientModel client;
        SellerModel seller;

        // TASK 1
        [Fact]
        public async void When_SellerVatIsFalse_ReturnZero()
        {
            // Arrange
            client = new() { Region = "Europe", IsVatPayer = true };
            seller = new() { Region = "Antarctic", IsVatPayer = false};

            // Act
            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            // Assert
            Assert.Equal(0, result);
        }

        // TASK 2
        [Fact]
        public async void When_ClientNotFromEurope_ReturnZero()
        {
            // Arrange
            client = new() { Region = "Asia" };
            seller = new(){ Region = "Europe" };

            // Act
            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            // Assert
            Assert.Equal(0, result);
        }

        // TASK 3
        [Fact]
        public async void When_ClientAndSellerNotFromSameRegion_ReturnSellerRegionVat()
        {
            // Arrange
            client = new() { Region = "Europe" };
            seller = new() { Region = "Asia" };

            // Act
            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            // Assert
            Assert.Equal(10, result);
        }

        // TASK 4
        [Fact]
        public async void When_ClientAndSellerFromSameRegion_ReturnRegionVat()
        {
            // Arrange
            client = new() { Region = "Central America" };
            seller = new() { Region = "Central America" };

            // Act
            await Task.Run(() => countryServices.GetCountriesFromApiAsync());
            var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

            // Assert
            Assert.Equal(30, result);
        }
    }
}