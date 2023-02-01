using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvoiceTask.Business.Services;

public class InvoiceServices : IInvoiceServices
{
    ICalculateVatServices _calculateVatServices;

    public InvoiceServices()
    {
        _calculateVatServices = new CalculateVatServices();
    }

    public string GenerateInvoiceWithVat(OrdersModel order)
    {
        var vatResult = _calculateVatServices.CheckVatForClient(order.Client, order.Seller);
        string modelJson = "";
        

        if (order != null)
        {
            for (int i = 0; i < order.OrdersLines.Count; i++)
            {
                var result = order.OrdersLines[i].Amount * order.OrdersLines[i].Product.Price;

                order.OrdersLines[i].Total = result;

                order.Total = order.Total + order.OrdersLines[i].Total;
            }

            if (Convert.ToDouble(vatResult) == 0)
            {
                order.Vat = 0;
                order.TotalWithVat = order.Total;
            }
            else if (order.Discount !=0)
            {
                var vatPercent = vatResult;
                order.Vat = (int)vatPercent;
                var total = order.Total;
                decimal discount = (decimal)total * ((decimal)order.Discount / 100) ;
                var totalWIthDiscount = total - (double)discount;
                var totalWithVat = totalWIthDiscount + (totalWIthDiscount * (vatPercent / 100));
                order.TotalWithVat = Math.Round(totalWithVat, 2);
            }
            else
            {
                var vatPercent = vatResult;
                order.Vat = (int)vatPercent;
                var totalWithVat = order.Total + order.Total * (vatPercent / 100);
                order.TotalWithVat = Math.Round(totalWithVat, 2);
            }

             modelJson = JsonConvert.SerializeObject(order);
        }
        return modelJson;
    }
}

   
