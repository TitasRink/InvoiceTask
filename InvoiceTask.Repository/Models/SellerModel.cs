namespace InvoiceTask.Repository.Models;

public class SellerModel 
{
    public string Name { get; set; }
    public string Region { get; set; }
    public bool IsVatPayer { get; set; } = true;
}
