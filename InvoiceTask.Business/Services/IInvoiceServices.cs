namespace InvoiceTask.Business.Services
{
    public interface IInvoiceServices
    {
        string GenerateInvoiceWithVat(OrdersModel order);
    }
}