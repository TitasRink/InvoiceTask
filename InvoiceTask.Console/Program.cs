using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

IInvoiceServices invoiceServices = new InvoiceServices();

// Creating model to generate Invoice

List<OrderLineModel> productListOne = new()
{
    new (new ProductModel("Kefyras", 2.0) , 2),
    new (new ProductModel("Bananas", 1.5), 3),
    new (new ProductModel("Pienas", 1.0), 1),
    new (new ProductModel("Kava", 8.50), 2)
};

CustomerModel cutomerOne = new ("im.k. 384456222",
                                "LT31544654156465132",
                                "Liepu g. 25",
                                "UAB Perku",
                                true,
                                "Asia");

SupplierModel supplierOne = new ("UAB Parduodu",
                                 "Asia",
                                 true,
                                 "im.k. 45661213123",
                                 "Klaipedos g. 25-5",
                                 "LT231321232323231");

OrdersModel orderOne = new (supplierOne, cutomerOne, productListOne);
OrdersModel orderWithDisciunt = new(supplierOne, cutomerOne, productListOne, 5);



var InvoiceResult = invoiceServices.GenerateInvoiceWithVat(orderOne);
Console.WriteLine(InvoiceResult);


