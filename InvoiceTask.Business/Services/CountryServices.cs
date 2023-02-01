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

            if (obj != null)
            {
                foreach (var entry in obj.CountriesData)
                {
                    root.Add(entry.Key, entry.Value);
                }
                AddVatToCountries(root);
                return root;
            }
            throw new Exception();
        }
        throw new Exception();
    }

    //Adding Vat to regions
    public void AddVatToCountries(Dictionary<string, CountriesModel> model)
    {
        double Africa = 20;
        double Antarctic = 15;
        double Asia = 10;
        double CentralAmerica = 30;
        double Europe = 21;

        var regionDistinct = model.Values.Select(x => x.Region).Distinct().ToList();

        if (regionDistinct != null)
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
    }
}

