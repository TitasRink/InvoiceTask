using System;
using System.ComponentModel;

namespace InvoiceTask.Repository.Models;

public class OrdersModel
{
    public SupplierModel Seller { get; set; }
    public CustomerModel Client { get; set; }
    public List<OrderLineModel> OrdersLines { get; set; }
    public double Total { get; set; }
    public int _discount { get; set; }
    public int _vat { get; set; }
    public double TotalWithVat { get; set; }


    public OrdersModel(SupplierModel seller, CustomerModel client, List<OrderLineModel> ordersLines)
    {
        Seller = seller;
        Client = client;
        OrdersLines = ordersLines;
    }
    public OrdersModel(SupplierModel seller, CustomerModel client, List<OrderLineModel> ordersLines, int discount)
    {
        _discount = discount;
        Seller = seller;
        Client = client;
        OrdersLines = ordersLines;
    }

    public int Discount
    {
        get { return _discount; }
        set
        {
            if (value > 0 && value < 40)
            {
                _discount = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Discount", "Discount cannot be less then 0, or greater than 40.");
            }
        }
    }

    public int Vat
    {
        get { return Convert.ToInt32(_vat); }
        set
        {
            if (value > 0 && value < 100)
            {
                _vat = Convert.ToInt32(value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Vat", "Vat cannot be less then 0, or greater than 100.");
            }
        }
    }
}