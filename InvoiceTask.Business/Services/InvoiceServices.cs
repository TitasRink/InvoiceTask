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
        OrdersModel returnOrder = order;
        var vatResult = _calculateVatServices.CheckVatForClient(order.Client, order.Seller);
        string modelJson = "";

        if (returnOrder != null)
        {
            for (int i = 0; i < returnOrder.OrdersLines.Count; i++)
            {
                var result = returnOrder.OrdersLines[i].Amount * returnOrder.OrdersLines[i].Product.Price;
                returnOrder.OrdersLines[i].Total = result;
                returnOrder.Total = returnOrder.Total + returnOrder.OrdersLines[i].Total;
            }

            if (Convert.ToDouble(vatResult) == 0)
            {
                returnOrder.Vat = 0;
                returnOrder.TotalWithVat = returnOrder.Total;
            }
            else if (returnOrder.Discount !=0)
            {
                var vatPercent = vatResult;
                returnOrder.Vat = (int)vatPercent;
                var total = returnOrder.Total;
                decimal discount = (decimal)total * ((decimal)returnOrder.Discount / 100) ;
                var totalWIthDiscount = total - (double)discount;
                var totalWithVat = totalWIthDiscount + (totalWIthDiscount * (vatPercent / 100));
                returnOrder.TotalWithVat = Math.Round(totalWithVat, 2);
            }
            else
            {
                var vatPercent = vatResult;
                returnOrder.Vat = (int)vatPercent;
                var totalWithVat = returnOrder.Total + returnOrder.Total * (vatPercent / 100);
                returnOrder.TotalWithVat = Math.Round(totalWithVat, 2);
            }

             modelJson = JsonConvert.SerializeObject(returnOrder);
        }
        return modelJson;
    }
}

   
