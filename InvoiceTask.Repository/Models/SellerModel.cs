namespace InvoiceTask.Repository.Models;

public class SellerModel 
{
    public string Region { get; set; }
    public bool IsVatPayer { get; set; } = true;
}
