using MediatR;
using Niko.Fire.Services.Accounts.Commands;

namespace Niko.Fire.Services.Tests;

public class CreateAccountTests(IMediator mediator)
{

    [Fact]
    public async Task Should_Return_ValidGuid_After_AccountCreation()
    {
        // Arrange
        var request = new CreateAccount { Name = "AVANZA" };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateAccountResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
}