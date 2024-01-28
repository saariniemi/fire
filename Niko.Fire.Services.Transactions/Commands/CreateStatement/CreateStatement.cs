using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Interfaces;
using Niko.Fire.Services.Accounts;

namespace Niko.Fire.Services.Transactions.Commands;

public class CreateStatement : IRequest<CreateStatementResponse>
{
    public required IAccount Account { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime Date { get; set; }
}

public class CreateStatementHandler(TransactionRepository transactionRepository) : IRequestHandler<CreateStatement, CreateStatementResponse>
{
    public async Task<CreateStatementResponse> Handle(CreateStatement request, CancellationToken cancellationToken)
    {
        // _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken); // TODO: ADD VALIDATOR

        var transaction = new Transaction
        {
            AccountId = request.Account.Id,
            // Tags = [new Tag { Name = "STATEMENT"}], // TODO: FIX
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

public class CreateStatementResponse(CreateStatement request) : IResponse<CreateStatement>
{
    public CreateStatement Request { get; } = request;
    public Guid Id { get; set; }
}