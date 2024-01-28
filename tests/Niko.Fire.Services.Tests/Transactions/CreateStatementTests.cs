using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Transactions.Commands;

namespace Niko.Fire.Services.Tests;

public class CreateStatementTests(IMediator mediator)
{
    [Fact]
    public async Task Should()
    {
        // Assign
        var request = new CreateStatement
        {
            Account = new Account { Id = Guid.NewGuid() },
            Amount = 100,
            Date = DateTime.Now
        };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateStatementResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
}