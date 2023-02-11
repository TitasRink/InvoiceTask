using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly ICountryServices _countryServices;
        private readonly IInvoiceServices _invoiceServices;

        List<OrderLineModel> productListOne = new()
            {
             new (new ProductModel("Kefyras", 2.0) , 2),
             new (new ProductModel("Bananas", 3), 3),
             new (new ProductModel("Pienas", 1.0), 1),
              new (new ProductModel("Kava", 8.50), 2)
            };

        CustomerModel cutomerOne = new("im.k. 384456222",
                                "LT31544654156465132",
                                "Liepu g. 25",
                                "UAB Perku",
                                true,
                                "Europe");

        CustomerModel cutomerTwo = new("im.k. 384456222",
                                "LT31544654156465132",
                                "Liepu g. 25",
                                "UAB Perku",
                                true,
                                "Antarctic");

        SupplierModel supplierOne = new("UAB Parduodu",
                                         "Europe",
                                         true,
                                         "im.k. 45661213123",
                                         "Klaipedos g. 25-5",
                                         "LT231321232323231");

        SupplierModel supplierTwo = new("UAB Internetas",
                                         "Antarctic",
                                         true,
                                         "im.k. 45661213123",
                                         "Klaipedos g. 25-5",
                                         "LT231321232323231");

        public InvoiceController(ICountryServices countryServices, IInvoiceServices invoiceServices)
        {
            _countryServices = countryServices;
            _invoiceServices = invoiceServices;
        }

        [HttpGet("GetDataFromAPI")]
        public string GetDataFromAPI()
        {
            var resultApi = _countryServices.GetCountriesFromApiAsync().Result;

            if (resultApi is not null)
            {
                return "Get data complete";
            }
            return "Failed to get data";
        }


        [HttpPost("WriteInvoiceToClient")]
        public string WriteInvoiceToClientReturnString(int selectNum)
        {
            OrdersModel orderOne = new(supplierOne, cutomerOne, productListOne);
            OrdersModel orderWithDisciunt = new(supplierOne, cutomerOne, productListOne, 5);
            OrdersModel orderWithoutVat = new(supplierTwo, cutomerOne, productListOne, 5);
            OrdersModel orderWithVat = new(supplierTwo, cutomerTwo, productListOne);


            if (selectNum == 1)
            {
                var invoiceResult = _invoiceServices.GenerateInvoiceWithVat(orderOne);
                return invoiceResult;
            }
            if(selectNum == 2)
            {
                var invoiceResult = _invoiceServices.GenerateInvoiceWithVat(orderWithDisciunt);
                return invoiceResult;
            }
            if(selectNum == 3)
            {
                var invoiceResult = _invoiceServices.GenerateInvoiceWithVat(orderWithoutVat);
                return invoiceResult;
            }
            if (selectNum == 4)
            {
                var invoiceResult = _invoiceServices.GenerateInvoiceWithVat(orderWithVat).ToString();
                return invoiceResult;
            }
            return "Please select number 1 - 4";
        }
    }
}
