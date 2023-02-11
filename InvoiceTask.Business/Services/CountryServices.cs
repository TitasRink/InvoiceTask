using Newtonsoft.Json;

namespace InvoiceTask.Business.Services;

public class CountryServices : ICountryServices
{
    public async Task<Dictionary<string, CountriesModel>> GetCountriesFromApiAsync()
    {
        Dictionary<string, CountriesModel> root = new();

        using var client = new HttpClient();
        var response = await client.GetAsync("https://api.first.org/data/v1/countries");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            RootCountryObject obj = JsonConvert.DeserializeObject<RootCountryObject>(data);

            if (obj is not null)
            {
                foreach (var entry in obj.CountriesData)
                {
                    root.Add(entry.Key, entry.Value);
                }
                AddVatToCountries(root);
                return root;
            }
            throw new NullReferenceException("no data found in json");
        }
        throw new NullReferenceException("Something is wrong with connection. Please try again later");
    }

    //Adding Vat to regions
    public void AddVatToCountries(Dictionary<string, CountriesModel> model)
    {
        const double Africa = 20;
        const double Antarctic = 15;
        const double Asia = 10;
        const double CentralAmerica = 30;

        var regionDistinct = model.Values.Select(x => x.Region).Distinct().ToList();

        if (regionDistinct is not null)
        {
            for (int i = 0; i < regionDistinct.Count; i++)
            {
                foreach (var item in model.Values.Where(x => x.Region == regionDistinct[0].ToString()))
                {
                    item.CountryVat = Africa;
                }
                foreach (var item in model.Values.Where(x => x.Region == regionDistinct[1].ToString()))
                {
                    item.CountryVat = Antarctic;
                }
                foreach (var item in model.Values.Where(x => x.Region == regionDistinct[2].ToString()))
                {
                    item.CountryVat = Asia;
                }
                foreach (var item in model.Values.Where(x => x.Region == regionDistinct[3].ToString()))
                {
                    item.CountryVat = CentralAmerica;
                }
            }
        }
        throw new NullReferenceException("No data found");
    }
}

