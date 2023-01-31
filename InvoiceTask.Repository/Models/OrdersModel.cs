namespace InvoiceTask.Repository.Models;

public class OrdersModel
{
    public SellerModel Seller { get; set; }
    public ClientModel Client { get; set; }
    public List<OrderLineModel> OrdersLines { get;set; }
    public double TotalWithVat { get; set; }
    public double Total { get; set; }
    public double Vat { get; set; }

    public OrdersModel(SellerModel seller, ClientModel client, List<OrderLineModel> ordersLines)
    {
        Seller = seller;
        Client = client;
        OrdersLines = ordersLines;
    }
}
