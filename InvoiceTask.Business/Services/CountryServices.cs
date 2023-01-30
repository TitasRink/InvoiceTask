using InvoiceTask.Repository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Business.Services;

public class CountryServices : ICountryServices
{
    public async Task<Dictionary<string, CountriesModel>> GetCountriesFromApiAsync()
    {
        var root = new Dictionary<string, CountriesModel>();
        //using (var client = new HttpClient())
        //{
        //    var response = await client.GetAsync("https://api.first.org/data/v1/countries");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Random rnd = new Random();
        //        string data = await response.Content.ReadAsStringAsync();
        //        RootCountryObject obj = JsonConvert.DeserializeObject<RootCountryObject>(data);
        //        foreach (var entry in obj.CountriesData)
        //        {
        //            root.Add(entry.Key, entry.Value);
        //        }



        //    }
        //    return root;
        //}

        using (var client = new HttpClient())
        {
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
                    return root;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }

    public async void AddVatToCountries()
    {
        var model = await GetCountriesFromApiAsync();
        var vat1 = 20;
        var vat2 = 15;
        var vat3 = 10;
        var vat4 = 30;

        var regionDistinct = model.Values.Select(x => x.Region).Distinct().ToList();

        for (int i = 0; i < regionDistinct.Count; i++)
        {
            foreach (var item in model.Values.Where(x => x.Region == regionDistinct[0].ToString()))
            {
                item.CountryVat = vat1;
            }
            foreach (var item in model.Values.Where(x => x.Region == regionDistinct[1].ToString()))
            {
                item.CountryVat = vat2;
            }
            foreach (var item in model.Values.Where(x => x.Region == regionDistinct[2].ToString()))
            {
                item.CountryVat = vat3;
            }
            foreach (var item in model.Values.Where(x => x.Region == regionDistinct[3].ToString()))
            {
                item.CountryVat = vat4;
            }
        }
    }
}

