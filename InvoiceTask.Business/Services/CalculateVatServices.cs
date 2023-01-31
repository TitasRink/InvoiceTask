namespace InvoiceTask.Business.Services;

public class CalculateVatServices : ICalculateVatServices
{
    ICountryServices _countryServices = new CountryServices();

    public CalculateVatServices()
    {
      
    }

    public double CheckVatForClient(ClientModel client, SellerModel seller)
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
        double vat = coutryResult.Values.FirstOrDefault(x => x.Region == countryCode).CountryVat;    
        return vat;
    }
}

