using InvoiceTask.Repository.Models;

namespace InvoiceTask.Business.Services
{
    public interface ICountryServices
    {
        void AddVatToCountries();
        Task<Dictionary<string, CountriesModel>> GetCountriesFromApiAsync();
    }
}