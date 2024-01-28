namespace Niko.Fire.Services.Tests;
using MediatR;
using Accounts.Requests;
using Loans.Commands;

public class GetAccountTests(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_Account_After_CreateLoan()
    {
        // Arrange
        var createLoan = new CreateLoan()
        {
            Name = "KLARNA",
            PrincipalAmount = 1000,
            RemainingBalance = 0,
            OriginationDate = DateTime.Now,
            MaturityDate = DateTime.Now.AddMonths(3)
        };
        
        var setup = await mediator.Send(createLoan, CancellationToken.None);

        // Act
        var getAccount = new GetAccount
        {
            Id = setup.AccountId
        };
        
        var result = await mediator.Send(getAccount, CancellationToken.None);

        // Assert
        Assert.IsType<Account>(result);
        Assert.Equal("KLARNA", result.Name);
        
        
        
    }
}