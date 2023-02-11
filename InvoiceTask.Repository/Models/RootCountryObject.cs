using Newtonsoft.Json;

namespace InvoiceTask.Repository.Models;

public class RootCountryObject
{
    [JsonProperty("data")]
    public Dictionary<string, CountriesModel> CountriesData { get; set; } = new Dictionary<string, CountriesModel>();
}
