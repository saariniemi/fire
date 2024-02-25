using MediatR;
using Niko.Fire.Infrastructure.Interfaces;
using Niko.Fire.Services.Accounts;
using Account = Niko.Fire.Services.Accounts.Account;

namespace Niko.Fire.Services.Transactions.Commands.CreateTransaction;

public class CreateTransaction : IRequest<CreateTransactionResponse>
{
    public required Account Account { get; set; }
    public string? Description { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime Date { get; set; }
}