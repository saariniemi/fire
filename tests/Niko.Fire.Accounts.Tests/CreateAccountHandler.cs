using Moq;
using Niko.Fire.Accounts.Commands;
using Niko.Fire.Accounts.Handlers;
using Niko.Fire.Accounts.Responses;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Tests;

public class CreateAccountHandler
{
    [Fact]
    public async Task Given_CreateAccount_With_Name_When_Handle_Then_Returns_Guid()
    {
        Guid newId = Guid.NewGuid();
        
        // Arrange
        var request = new CreateAccount { Name = "AVANZA" };

        var mockRepository = new Mock<AccountRepository>(null);
        mockRepository.Setup(repo => repo.SaveItemAsync(It.IsAny<Account>()))
            .Callback<Account>(value => value.Id = newId)
            .ReturnsAsync(1);
        
        var sut = new Handlers.CreateAccountHandler(mockRepository.Object);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateAccountResponse>(result);
        Assert.Equal(newId, result.Id);
    }
}