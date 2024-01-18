using Microsoft.VisualBasic.FileIO;
using Moq;
using Niko.Fire.Accounts.Commands;
using SQLite;

namespace Niko.Fire.Accounts.Tests;

public class CreateAccountHandlerTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    public CreateAccountHandlerTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task Should_Return_ValidGuid_After_AccountCreation()
    {
        // Arrange
        var request = new CreateAccount { Name = "AVANZA" };
        
        var sut = new CreateAccountHandler(_databaseFixture.AccountRepository);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsType<CreateAccountResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
}