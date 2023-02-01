using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;

namespace InvoiceTask.Repository.Models;

public class OrdersModel
{
    public int Id { get; set; }
    public SupplierModel Seller { get; set; }
    public CustomerModel Client { get; set; }
    public List<OrderLineModel> OrdersLines { get; set; }
    public double Total { get; set; }
    public int _discount { get; set; }
    public int _vat { get; set; }
    public double TotalWithVat { get; set; }

    public OrdersModel()
    {

    }

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
        get
        {
            if (_discount > -1 && _discount < 40)
            {
                return _discount;
            }
            throw new ArgumentOutOfRangeException("Discount", "Discount cannot be less then 0, or greater than 40.");
        }

        set
        {
            if (_discount > -1 && _discount < 40)
            {
                _discount = value;
            }
            throw new ArgumentOutOfRangeException("Discount", "Discount cannot be less then 0, or greater than 40.");
        }
    }

    public int Vat
    {
        get
        {
            if (_vat > -1 && _vat < 100)
            {
                return Convert.ToInt32(_vat);
            }
            throw new ArgumentOutOfRangeException("Vat", "Vat cannot be less then 0, or greater than 100.");
        }

        set
        {
            _vat = Convert.ToInt32(value);
        }
    }
}