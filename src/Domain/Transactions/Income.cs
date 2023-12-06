namespace PersonalFinances.src.Domain.Transactions;

public class Income : Transaction
{
	public Income()
    {

    }

    public Income(string name, string description, decimal amount, DateTime dueDate, string note)
        : base(name, description, amount, dueDate, note)
    {
        
    }
}
