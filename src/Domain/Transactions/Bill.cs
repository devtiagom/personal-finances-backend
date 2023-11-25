namespace PersonalFinances.src.Domain.Transactions;

public class Bill : Transaction
{
    public Bill()
    {

    }

    public Bill(
        string name,
        string description,
        decimal amount,
        DateTime dueDate,
        EBillType type,
        DateTime purchaseDate,
        int installments,
        int currentInstallment)
        : base(name, description, amount, dueDate)
    {
        Type = type;
        PurchaseDate = purchaseDate;
        Installments = installments;
        CurrentInstallment = currentInstallment;
    }

    public EBillType Type { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Installments { get; set; }
    public int CurrentInstallment { get; set; }
}
