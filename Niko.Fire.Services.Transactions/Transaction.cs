namespace Niko.Fire.Services.Transactions;

public class Transaction
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal? Statement { get; set; }
}