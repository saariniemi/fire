using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Transactions.Commands;

public class CreateStatementHandler(TransactionRepository transactionRepository) : IRequestHandler<CreateStatement, CreateStatementResponse>
{
    public async Task<CreateStatementResponse> Handle(CreateStatement request, CancellationToken cancellationToken)
    {
        // _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken); // TODO: ADD VALIDATOR

        var transaction = new Infrastructure.Transaction
        {
            Account = new Account { Id = request.Account.Id },
            Tags = new List<string> {"STATEMENT" },
            Amount = request.Amount,
            Date = request.Date,
        };
        
        await transactionRepository.SaveItemAsync(transaction);

        return new CreateStatementResponse(request)
        {
            Id = transaction.Id
        };
    }
}