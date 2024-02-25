using Niko.Fire.Services.Accounts;
using MediatR;
using Niko.Fire.Services.Accounts.Commands;
using Niko.Fire.Services.Accounts.Requests;
using Niko.Fire.Services.Loans.Commands;

namespace Niko.Fire.Services.Tests;

public class RequestAccount(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_Account_When_Requesting_CreatedLoan()
    {
        const string loanName = "SBAB";
        
        // Setup
        var createLoan = new CreateLoan { Name = loanName };
        var setup = await mediator.Send(createLoan, CancellationToken.None);
        
        // Arrange
        var getAccount = new GetAccount
        {
            Id = setup.AccountId
        };
        
        // Act
        var result = await mediator.Send(getAccount, CancellationToken.None);
        
        // Assert
        Assert.IsType<Account>(result);
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal(loanName, result.Name);
    }
}