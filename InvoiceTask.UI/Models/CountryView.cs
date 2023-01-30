using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InvoiceTask.UI.Models
{
    public class CountryView
    {
        [Display(Name = "Country Name")]
        public string Country { get; set; }

        [Display(Name = "Region Name")]
        public string Region { get; set; }

        public double CountryVat { get; set; }
    }
}
