namespace InvoiceTask.Repository.Models;

public class ProductModel
{
    public string Name { get; set; }
    public double Price { get; set; } = 0;
    public ProductModel(string name, double price)
    {
        Name = name;
        Price = price;
    }
}


