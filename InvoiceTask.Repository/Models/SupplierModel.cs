namespace InvoiceTask.Repository.Models;

public class SupplierModel : BaseSupplierCustomer
{
    public bool IsVatPayer { get; set; } = true;
    public string BusinessCode { get; set; } = string.Empty;


    public SupplierModel(string name, string region, bool isVatPayer, string businessCode, string address, string bankAccountCode)
    {
        Name = name;
        Region = region;
        IsVatPayer = isVatPayer;
        BusinessCode = businessCode;
        Address = address;
        BankAccountCode = bankAccountCode;
    }

    public SupplierModel(bool isVatPayer, string region )
    {
        IsVatPayer = isVatPayer ;
        Region = region;
    }
}
