namespace InvoiceTask.Repository.Models;

public class CustomerModel :BaseSupplierCustomer
{
    public int Id { get; set; }
    public bool IsBusinessCustomer { get; set; } = true;
    public string BusinessCode { get; set; }

    public CustomerModel(string businessCode, string banckAccountCode, string address, string name ,bool isBusinessCustomer, string region)
    {
        BusinessCode = businessCode;
        BankAccountCode = banckAccountCode;
        Address = address;
        Name = name;
        IsBusinessCustomer = isBusinessCustomer;
        Region = region;
    }
    public CustomerModel(bool isBusinessCustomer, string region)
    {
        IsBusinessCustomer = isBusinessCustomer;
        Region = region;
       
    }
}
