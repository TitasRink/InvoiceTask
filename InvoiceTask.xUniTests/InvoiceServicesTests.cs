using InvoiceTask.Business.Services;
using InvoiceTask.Repository.Models;

namespace InvoiceTask.xUniTests;

public class InvoiceServicesTests
{
    IInvoiceServices invoiceServices = new InvoiceServices();

    [Fact]
    public async void GeneratesInvoice_ReturnNotEmpty()
    {
        // Arrange
        CustomerModel cutomerOne = new(true, "Europe");
        SupplierModel supplierOne = new(false, "Antarctic");

        List<OrderLineModel> productListOne = new()
        {
            new (new ProductModel("Kefyras", 2.0) , 2),
            new (new ProductModel("Bananas", 1.5), 3),
        };

        OrdersModel orderOne = new(supplierOne, cutomerOne, productListOne);

        // Act
        var result = invoiceServices.GenerateInvoiceWithVat(orderOne);
        
        // Assert
        Assert.NotEmpty(result);

    }
}
