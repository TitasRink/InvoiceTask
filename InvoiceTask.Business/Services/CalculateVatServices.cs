using InvoiceTask.Repository.Models;


namespace InvoiceTask.Business.Services
{
    public class CalculateVatServices : ICalculateVatServices
    {
        private readonly ICountryServices _countryServices;

        public CalculateVatServices()
        {
            _countryServices = new CountryServices();
        }

        public double CheckVatForClient(ClientModel client, SellerModel seller)
        {
            if (seller.IsVat == false)
            {
                return 0;
            }
            if (seller.IsVat && client.ClientRegion != "Europe" && seller.Region == " Europe")
            {
                return 0;
            }
            if (seller.IsVat && client.ClientRegion == "Europe" && client.ClientRegion != seller.Region)
            {
                var result = GetVatByCountry(seller.Region);
                return result;
            }
            if (seller.IsVat && seller.Region == client.ClientRegion)
            {
                double result = GetVatByCountry(seller.Region);
                return result;
            }
            return 0;
        }

        private double GetVatByCountry(string countryCode)
        {
            var coutryResult = _countryServices.GetCountriesFromApiAsync().Result;

            var vat = coutryResult.Values.Where(x => x.Region == countryCode).FirstOrDefault().CountryVat;    

            return vat;
        }
    }
}

