using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Accounts.Commands;
using Niko.Fire.Services.Transactions.Commands;
using Niko.Fire.Services.Transactions.Commands.CreateTransaction;
using Niko.Fire.Services.Transactions.Requests.GetTransactions;

namespace Niko.Fire.Services.Tests;

public class CreateTransactionTests(IMediator mediator)
{
    [Fact]
    public async Task Should_ValidGuid_After_TransactionCreation()
    {
        var createAccount = new CreateAccount
        {
            Name = "SBAB"
        };

        var response = await mediator.Send(createAccount);
        
        
        var account = new Account { Id = response.Id };
        
        // Assign
        var request = new CreateTransaction
        {
            Account = account,
            Amount = 120,
            Description = "",
            Date = DateTime.Now
        };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateTransactionResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);

        var request2 = new GetTransactions()
        {
            Account = account
        };
        
        var t = await mediator.Send(request2, CancellationToken.None);
        var t1 = t.Single(x => x.Id == result.Id);

    }
}