using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Transactions.Commands;
using Niko.Fire.Services.Transactions.Commands.CreateTransaction;

namespace Niko.Fire.Services.Tests;

public class CreateTransactionTests(IMediator mediator)
{
    [Fact]
    public async Task Should_ValidGuid_After_TransactionCreation()
    {
        // Assign
        var request = new CreateTransaction
        {
            Account = new Account { Id = Guid.NewGuid() },
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
    }
}