namespace InvoiceTask.Repository.Models;

public class OrderLineModel 
{
    public int Id { get; set; }
    public ProductModel? Product { get; set; }
    public int _amount { get; set; } = 0;
    public double Total { get; set; }
    public OrderLineModel()
    {

    }

    public OrderLineModel(ProductModel product , int amount)
    {
        Product = product;
        _amount = amount;
    }
    public int Amount
    {
        get
        {
            if (_amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount", "Amount must be bigger then 0");
            }
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
