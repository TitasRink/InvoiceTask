using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;


IInvoiceServices invoiceServices = new InvoiceServices();

// Creating model to pass to method

List<OrderLineModel> productListOne = new()
{
    new (new ProductModel("Kefyras", 2.0) , 2),
    new (new ProductModel("Bananas", 1.5), 3),
    new (new ProductModel("Pienas", 1.0), 1),
    new (new ProductModel("Kava", 8.50), 2)
};

ClientModel clientEurope = new ClientModel(true, "Asia");
SellerModel sellerEurope = new SellerModel("UAB Parduodu", "Asia");
OrdersModel OrderOne = new OrdersModel(sellerEurope, clientEurope, productListOne);



invoiceServices.GenerateInvoiceWithVat(OrderOne);



