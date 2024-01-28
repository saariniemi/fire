using MediatR;
using Niko.Fire.Accounts.Commands;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Tests;

public class DeleteAccountTests(IMediator mediator)
{
    private readonly DeleteAccountValidator _deleteAccountValidator = new();

    [Fact]
    public async Task Should_Return_NumbersOfRowsDeleted()
    {
        var createAccount = new CreateAccount
        {
            Name = "LÄNSFÖRSÄKRINGAR"
        };
        
        var setup = await mediator.Send(createAccount, CancellationToken.None);
        
        // Arrange
        var request = new DeleteAccount { Id = setup.Id, Name = "LÄNSFÖRSÄKRINGAR" };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<DeleteAccountResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.Equal(1, result.NumberOfRowsDeleted);
    }
}