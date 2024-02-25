using MediatR;
using Niko.Fire.Services.Loans.Commands;


namespace Niko.Fire.Services.Tests;

public class CreateLoanTests(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_ValidGuid_After_LoanCreation()
    {
        // Arrange
        var request = new CreateLoan
        {
            Name = "SBAB"
        };
        
        // Act
        var result = await mediator.Send(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateLoanResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
}