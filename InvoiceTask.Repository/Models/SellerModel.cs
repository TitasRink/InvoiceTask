namespace InvoiceTask.Repository.Models;

public class SellerModel 
{
    public string Name { get; set; }
    public string Region { get; set; }
    public bool IsVatPayer { get; set; } = true;

    public SellerModel(string name, string region, bool isVatPayer)
    {
        Name = name;
        Region = region;
        IsVatPayer = isVatPayer;
    }

    public SellerModel(string name, string region)
    {
        Name = name;
        Region = region;
    }
}
