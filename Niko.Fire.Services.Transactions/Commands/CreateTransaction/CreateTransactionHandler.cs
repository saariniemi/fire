using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Transactions.Commands.CreateTransaction;

public class CreateTransactionHandler(TransactionRepository transactionRepository) : IRequestHandler<CreateTransaction, CreateTransactionResponse>
{
    public async Task<CreateTransactionResponse> Handle(CreateTransaction request, CancellationToken cancellationToken)
    {
        // _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken); // TODO: VALIDATOR

        var transaction = new Infrastructure.Transaction
        {
            AccountId = request.Account.Id,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date,
        };
        
        await transactionRepository.SaveItemAsync(transaction);

        return new CreateTransactionResponse(request)
        {
            Id = transaction.Id
        };
    }
}