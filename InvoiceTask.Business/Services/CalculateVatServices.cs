namespace InvoiceTask.Business.Services;

public class CalculateVatServices : ICalculateVatServices
{
    private ICountryServices _countryServices;

    public CalculateVatServices()
    {
        _countryServices = new CountryServices();
    }

    public double CheckVatForClient(CustomerModel client, SupplierModel seller)
    {
        if (client == null || seller == null)
        {
            throw new Exception();
        }
        if (seller.IsVatPayer == false)
        {
            return 0;
        }
        if (seller.IsVatPayer && client.Region != "Europe" && seller.Region == " Europe")
        {
            return 0;
        }
        if (seller.IsVatPayer && client.Region == "Europe" && client.Region != seller.Region)
        {
            double result = GetVatByCountry(seller.Region);
            return result;
        }
        if (seller.IsVatPayer && seller.Region == client.Region)
        {
            double result = GetVatByCountry(seller.Region);
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

