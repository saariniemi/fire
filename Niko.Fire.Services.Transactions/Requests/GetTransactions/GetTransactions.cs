using MediatR;
using Niko.Fire.Infrastructure.Interfaces;

namespace Niko.Fire.Services.Transactions.Requests.GetTransactions;

public class GetTransactions : IRequest<IEnumerable<Transaction>>
{
    public required IAccount Account { get; set; }
}