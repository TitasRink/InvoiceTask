using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Repository.Models
{
    public class RootCountryObject
    {

        [JsonProperty("data")]
        public Dictionary<string, CountriesModel> CountriesData { get; set; }
    }
}
