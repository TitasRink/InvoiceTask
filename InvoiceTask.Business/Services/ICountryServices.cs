using InvoiceTask.Repository.Models;

namespace InvoiceTask.Business.Services
{
    public interface ICountryServices
    {
        void AddVatToCountries(Dictionary<string, CountriesModel> model);
        Task<Dictionary<string, CountriesModel>> GetCountriesFromApiAsync();
    }
}