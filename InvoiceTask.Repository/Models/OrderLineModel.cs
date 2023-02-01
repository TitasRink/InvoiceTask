namespace InvoiceTask.Repository.Models;

public class OrderLineModel 
{
    public ProductModel Product { get; set; }
    public int _amount { get; set; } = 0;
    public double Total { get; set; }

    public OrderLineModel(ProductModel product , int amount)
    {
        Product = product;
        _amount = amount;
    }
    public int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            if(_amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount", "Amount must be bigger then 0");
            }
            _amount = value;
        }
    }
}
