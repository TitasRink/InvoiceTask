namespace InvoiceTask.Business.Services
{
    public interface ICalculateVatServices
    {
        double CheckVatForClient(CustomerModel client, SupplierModel seller);
    }
}