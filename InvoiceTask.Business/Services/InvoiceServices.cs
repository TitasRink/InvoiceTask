using Newtonsoft.Json;

namespace InvoiceTask.Business.Services;

public class InvoiceServices : IInvoiceServices
{
    ICalculateVatServices _calculateVatServices;

    public InvoiceServices()
    {
        _calculateVatServices = new CalculateVatServices();
    }

    public void GenerateInvoiceWithVat(OrdersModel order)
    {
        var vatResult = _calculateVatServices.CheckVatForClient(order.Client, order.Seller);

        for (int i = 0; i < order.OrdersLines.Count; i++)
        {
            order.Total = +order.OrdersLines[i].Amount * order.OrdersLines[i].Product.Price;
        }

        if (Convert.ToDouble(vatResult) == 0)
        {
            order.Vat = 0;
            order.TotalWithVat = order.Total;
        }
        else
        {
            var vatPercent = Convert.ToDouble(vatResult);
            order.Vat = vatPercent;

            order.TotalWithVat = order.Total + order.Total * (vatPercent / 100);
        }

        var modelJson = JsonConvert.SerializeObject(order);
        Console.WriteLine(modelJson);

    }
}

   
