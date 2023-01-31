namespace InvoiceTask.Repository.Models;

public class OrderLineModel
{
    public ProductModel Product { get; set; }
    public int Amount { get; set; } = 0;
    public OrderLineModel(ProductModel product , int amount)
    {
        Product = product;
        Amount = amount;
    }
}
