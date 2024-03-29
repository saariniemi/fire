using MediatR;
using Niko.Fire.Services.Loans.Commands;

namespace Niko.Fire.Services.Tests;

public class DeleteLoanTests(IMediator mediator)
{
    [Fact]
    public async Task Should_Return_NumbersOfRowsDeleted()
    {
        var createLoan = new CreateLoan()
        {
            Name = "SBAB"
        };
        
        var setup = await mediator.Send(createLoan, CancellationToken.None);
        
        // Arrange
        var request = new DeleteLoan()
        {
            Id = setup.Id,
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