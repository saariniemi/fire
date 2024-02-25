namespace Niko.Fire.Services.Transactions.Extensions;

public static class TransactionExtensions
{
    public static Transaction ToTransaction(this Infrastructure.Transaction item)
    {
        return new Transaction
        {
            Id = item.Id,
            Description = item.Description,
            Amount = item.Amount,
            Statement = item.Statement,
            Date = item.Date
        };
    }
}