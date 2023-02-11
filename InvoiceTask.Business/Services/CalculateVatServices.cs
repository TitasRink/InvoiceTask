namespace InvoiceTask.Business.Services;

public class CalculateVatServices : ICalculateVatServices
{
    private readonly ICountryServices _countryServices;

    public CalculateVatServices()
    {
        _countryServices = new CountryServices();
    }

    public double CheckVatForClient(CustomerModel customer, SupplierModel supplier)
    {
        if (customer is null || supplier.Region is null)
        {
            throw new NullReferenceException("No customer or supplier found");
        }
        else
        {
            if (supplier.IsVatPayer == false || supplier.IsVatPayer && customer.Region != "Europe" && supplier.Region == " Europe")
            {
                return 0;
            }
            if (supplier.IsVatPayer && customer.Region == "Europe" && customer.Region != supplier.Region ||
                supplier.IsVatPayer && supplier.Region == customer.Region)
            {
                double result = GetVatByCountry(supplier.Region);
                return result;
            }
            return 0;
        }
    }

    private double GetVatByCountry(string countryCode)
    {
        var coutryResult = _countryServices.GetCountriesFromApiAsync().Result;
        var result = (coutryResult is null || coutryResult.Values.First(x => x.Region == countryCode).CountryVat == 0) 
            ? throw new NullReferenceException("Error no info found") 
            : coutryResult.Values.Where(x => x.Region == countryCode).First().CountryVat;

        return result;
    }
}

