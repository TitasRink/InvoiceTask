using Newtonsoft.Json;

namespace InvoiceTask.Repository.Models;

public class CountriesModel
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    public double CountryVat { get; set; }
}
