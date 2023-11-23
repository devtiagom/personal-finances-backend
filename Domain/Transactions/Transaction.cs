namespace PersonalFinances.Domain.Transactions
{
    public abstract class Transaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Payed { get; set; }
    }
}
