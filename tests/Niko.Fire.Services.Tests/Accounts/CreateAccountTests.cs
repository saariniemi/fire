using MediatR;
using Niko.Fire.Accounts.Commands;

namespace Niko.Fire.Services.Tests;

public class CreateAccountTests(IMediator mediator)
{
    private readonly CreateAccountValidator _createAccountValidator = new();

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