namespace InvoiceTask.Business.Services;

public class CalculateVatServices : ICalculateVatServices
{
    private ICountryServices _countryServices;

    public CalculateVatServices()
    {
        _countryServices = new CountryServices();
    }

    public double CheckVatForClient(CustomerModel customer, SupplierModel supplier)
    {
        if (customer == null || supplier == null)
        {
            throw new Exception();
        }
        if (supplier.IsVatPayer == false)
        {
            return 0;
        }
        if (supplier.IsVatPayer && customer.Region != "Europe" && supplier.Region == " Europe")
        {
            return 0;
        }
        if (supplier.IsVatPayer && customer.Region == "Europe" && customer.Region != supplier.Region)
        {
            double result = GetVatByCountry(supplier.Region);
            return result;
        }
        if (supplier.IsVatPayer && supplier.Region == customer.Region)
        {
            double result = GetVatByCountry(supplier.Region);
            return result;
        }
        return 0;
    }

    private double GetVatByCountry(string countryCode)
    {
        var coutryResult = _countryServices.GetCountriesFromApiAsync().Result;
        if (coutryResult == null)
        {
            throw new Exception();
        }
        if(coutryResult.Values.Where(x => x.Region == countryCode).FirstOrDefault().CountryVat == null)
        {
            throw new Exception();
        }

        double vat = coutryResult.Values.Where(x => x.Region == countryCode).FirstOrDefault().CountryVat;    
        return vat;
    }
}

