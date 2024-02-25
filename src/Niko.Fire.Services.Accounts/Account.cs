using Niko.Fire.Infrastructure.Interfaces;

namespace Niko.Fire.Services.Accounts;

public class Account : IAccount
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid LoanId { get; set; }
}