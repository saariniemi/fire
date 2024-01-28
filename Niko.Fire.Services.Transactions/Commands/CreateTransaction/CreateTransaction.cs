using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Interfaces;
using Niko.Fire.Services.Accounts;
using Account = Niko.Fire.Services.Accounts.Account;

namespace Niko.Fire.Services.Transactions.Commands.CreateTransaction;

public class CreateTransaction : IRequest<CreateTransactionResponse>
{
    public required IAccount Account { get; set; }
    public string[] Tags { get; set; }
    public string? Description { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime Date { get; set; }
}

public class CreateTransactionHandler(TransactionRepository transactionRepository) : IRequestHandler<CreateTransaction, CreateTransactionResponse>
{
    public async Task<CreateTransactionResponse> Handle(CreateTransaction request, CancellationToken cancellationToken)
    {
        // _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken); // TODO: VALIDATOR

        var transaction = new Transaction
        {
            AccountId = request.Account.Id,
            // Tags = request.Tags.Select(x => new Tag{ Name = x }).ToArray(), // TODO: FIX
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

public class CreateTransactionResponse(CreateTransaction request) : IResponse<CreateTransaction>
{
    public CreateTransaction Request { get; } = request;
    public Guid Id { get; set; }
}