using InvoiceTask.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Business.Services
{
    public class CalculateVatServices
    {
        private readonly CountryServices _countryServices;
     

        public async Task<double> CheckVatForClient(ClientModel client, SellerModel seller)
        {


            if (seller.IsVat == false)
            {
                return 0;
            }
            if (seller.IsVat && client.ClientRegion != "Europe")
            {
                return 0;
            }
            if (seller.IsVat && client.ClientRegion == "Europe" && client.ClientRegion != seller.Region)
            {
                var result = await GetVatByCountry(seller.Region);
                return result;
            }
            if (seller.IsVat && seller.Region == client.ClientRegion)
            {
                double result = await GetVatByCountry(seller.Region);
                return result;
            }
            return 0;


        }

        private async Task<double> GetVatByCountry(string countryCode)
        {
            var coutryResult = await _countryServices.GetCountriesFromApiAsync();
            var vat = coutryResult.Values.FirstOrDefault(x => x.Country == countryCode).CountryVat;
            return vat;
        }
    }
}
