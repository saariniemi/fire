using MediatR;
using Niko.Fire.Services.Accounts.Requests;
using Niko.Fire.Infrastructure;
using Niko.Fire.Services.Loans.Commands;
using Account = Niko.Fire.Services.Accounts.Requests.Account;


namespace Niko.Fire.Services.Tests;

public class CreateLoanWithFixedRateTests(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_ValidGuid_After_LoanCreation()
    {
        // Arrange
        var request = new CreateLoanWithFixedRate
        {
            Name = "SBAB",
            PrincipalAmount = 1000,
            OriginationDate = DateTime.Now,
            Rate = 0.01M,
            PeriodInYears = 1,
            Amortization = 1000
        };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateLoanWithFixedRateResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
}