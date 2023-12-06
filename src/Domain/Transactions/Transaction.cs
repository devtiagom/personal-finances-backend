namespace PersonalFinances.src.Domain.Transactions;

public abstract class Transaction : BaseEntity
{
    public Transaction() => Payed = false;

    public Transaction(string name, string description, decimal amount, DateTime dueDate, string note) : this()
    {
        Name = name;
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        Note = note;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool Payed { get; set; }
    public string Note { get; set; }
}
