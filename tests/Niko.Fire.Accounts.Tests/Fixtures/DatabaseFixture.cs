using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Tests;

public class DatabaseFixture : IDisposable
{
    private const string Path = "./LocalStorage.db3";
    
    private class InfrastructureConfiguration : IConfiguration
    {
        public string DatabasePath => Path;
    }
    
    public DatabaseFixture()
    {
        File.Delete(Path);
        AccountRepository = new AccountRepository(new InfrastructureConfiguration());
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public AccountRepository AccountRepository { get; }
}