using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Services.Transactions.Commands;
using Niko.Fire.Services.Transactions.Extensions;

namespace Niko.Fire.Services.Transactions.Requests.GetTransaction;

public class GetTransactionsHandler(TransactionRepository transactionRepository) : IRequestHandler<GetTransactions.GetTransactions, IEnumerable<Transaction>>
{
    public async Task<IEnumerable<Transaction>> Handle(GetTransactions.GetTransactions request, CancellationToken cancellationToken)
    {
        var result = await transactionRepository.GetItemsAsync(request.Account);
        return result.Select(x => x.ToTransaction());
    }
}