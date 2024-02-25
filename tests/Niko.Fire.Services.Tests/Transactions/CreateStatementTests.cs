using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Transactions.Commands;
using Niko.Fire.Services.Transactions.Requests.GetTransactions;

namespace Niko.Fire.Services.Tests;

public class CreateStatementTests(IMediator mediator)
{
    [Fact]
    public async Task Should_ValidGuid_After_StatementCreation()
    {
        var account = new Account { Id = Guid.NewGuid() }; // TODO: NEED TO VERIFY ACCOUNT EXIST LATER
        
        // Assign
        var command = new CreateStatement
        {
            Account = account,
            Statement = 100,
            Date = DateTime.Now
        };
        
        // Act
        var result = await mediator.Send(command, CancellationToken.None);

        // Assert
        Assert.IsType<CreateStatementResponse>(result);
        Assert.Equal(command, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
        
        // Verify
        var request = new GetTransactions
        {
            Account = account
        };
        
        var transactions = await mediator.Send(request);

        Assert.Contains(transactions, item => item.Id == result.Id);
    }
}