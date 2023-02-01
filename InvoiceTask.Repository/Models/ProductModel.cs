using Newtonsoft.Json.Linq;

namespace InvoiceTask.Repository.Models;

public class ProductModel
{
    public string _name { get; set; }
    public double _price { get; set; } = 0;
    public ProductModel(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public double Price
    {
        get
        {
            if (_price < 0)
            {
                throw new ArgumentOutOfRangeException("Price", "Price cannot be less then 0");
            }
            return _price;
        }
        set
        {
            if (_price < 0)
            {
                throw new ArgumentOutOfRangeException("Price", "Price cannot be less then 0");
            }
            _price = value;
        }
    }

    public string Name 
    { 
        get
        {
            if (_name.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Name", "Name lenght much be bigger then 3 chars");
            }
            return _name; 
        }
        set
        {
            if (_name.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Name", "Name lenght much be bigger then 3 chars");
            }
            _name = value;
        }
             
    }
}


