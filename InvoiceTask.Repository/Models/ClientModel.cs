namespace InvoiceTask.Repository.Models;

public class ClientModel
{
    public bool isBusinessCustomer { get; set; } = true;
    public string Region { get; set; }

    public ClientModel(bool isBusinessCustomer, string region)
    {
        this.isBusinessCustomer = isBusinessCustomer;
        Region = region;
    }
}
