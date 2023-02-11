namespace InvoiceTask.Repository.Models;

public class BaseSupplierCustomer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? BankAccountCode { get; set; }
    public string? Region { get; set; }
}
