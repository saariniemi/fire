using MediatR;
using Niko.Fire.Accounts.Commands;
using Niko.Fire.Infrastructure;
using Niko.Fire.Loans.Commands;
using DeleteLoanHandler = Niko.Fire.Accounts.Commands.DeleteLoanHandler;

namespace Niko.Fire.Loans.Tests;

public class DeleteLoanHandlerTests(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_NumbersOfRowsDeleted()
    {
        var req = new CreateLoan()
        {
            Name = "SBAB",
            OriginationDate = DateTime.Now,
            MaturityDate = DateTime.Now.AddMonths(3),
            PrincipalAmount = 500000,
            RemainingBalance = 500000
        };
        
        var createLoanResponse = await mediator.Send(req, CancellationToken.None);
        
        // Arrange
        var request = new DeleteLoan()
        {
            Id = createLoanResponse.Id,
            Name = "SBAB"
        };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<DeleteLoanResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.Equal(1, result.NumberOfRowsDeleted);
    }
        
}