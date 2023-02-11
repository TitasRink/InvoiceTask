using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

namespace InvoiceTask.xUniTests;

public class CalculateVatServicesTests
{
    //VAT Africa = 20;
    //VAT Antarctic = 15;
    //VAT Asia = 10;
    //VAT CentralAmerica = 30;

    ICalculateVatServices vatServices = new CalculateVatServices();
    ICountryServices countryServices = new CountryServices();

    CustomerModel? client;
    SupplierModel? seller;

    // TASK 1
    [Fact]
    public async void When_SellerVatIsFalse_ReturnZero()
    {
        // Arrange
        client = new (true, "Europe");
        seller = new (false, "Antarctic");

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
        client = new (true, "Asia");
        seller = new (true, "Europe");

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
        client = new (true, "Europe");
        seller = new (true, "Asia");

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
        client = new (true, "Central America");
        seller = new (true, "Central America");

        // Act
        await Task.Run(() => countryServices.GetCountriesFromApiAsync());
        var result = await Task.Run(() => vatServices.CheckVatForClient(client, seller));

        // Assert
        Assert.Equal(30, result);
    }
}