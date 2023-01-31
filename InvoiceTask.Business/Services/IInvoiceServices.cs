namespace InvoiceTask.Business.Services
{
    public interface IInvoiceServices
    {
        void GenerateInvoiceWithVat(OrdersModel order);
    }
}