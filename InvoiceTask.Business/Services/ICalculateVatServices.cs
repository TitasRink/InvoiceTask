namespace InvoiceTask.Business.Services
{
    public interface ICalculateVatServices
    {
        double CheckVatForClient(ClientModel client, SellerModel seller);
    }
}