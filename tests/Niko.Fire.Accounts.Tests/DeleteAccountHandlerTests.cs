using Niko.Fire.Accounts.Commands;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Tests;

public class DeleteAccountHandlerTests : IClassFixture<DatabaseFixture>
{
    private readonly DeleteAccountValidator _deleteAccountValidator = new();
    
    private readonly DatabaseFixture _databaseFixture;
    public DeleteAccountHandlerTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
    }

    [Fact]
    public async Task Should_Return_ValidGuid_After_AccountCreation()
    {
        var x = new Account { Name = "AVANZA" }; // TODO: CREATE BETTER WAY TO SET UP SCENARIOS
        await _databaseFixture.AccountRepository.SaveItemAsync(x);
        
        // Arrange
        var request = new DeleteAccount { Id = x.Id, Name = "AVANZA" };
        
        var sut = new DeleteAccountHandler(_databaseFixture.AccountRepository, _deleteAccountValidator);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsType<DeleteAccountResponse>(result);
        Assert.Equal(request, result.Request);
        Assert.Equal(1, result.NumberOfRowsDeleted);
    }
}