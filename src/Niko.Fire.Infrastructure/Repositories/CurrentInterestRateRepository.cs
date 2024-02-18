using Niko.Fire.Infrastructure.Constants;
using SQLite;

namespace Niko.Fire.Infrastructure;

public class CurrentInterestRateRepository(IConfiguration configuration)
{
    private static SQLiteAsyncConnection? _database;

    /// <summary>
    /// Creates database
    /// if Its created already it will use that instance
    /// </summary>
    /// <returns></returns>
    private static async Task<SQLiteAsyncConnection> Init(string databasePath)
    {
        if (_database != null)
        {
            return _database;
        }

        _database = new SQLiteAsyncConnection(databasePath, Configuration.Flags);
        await _database.CreateTableAsync<CurrentInterestRate>();
        return _database;
    }

    public async Task<List<CurrentInterestRate>> GetItemsAsync()
    {
        var database = await Init(configuration.DatabasePath);
        return await database.Table<CurrentInterestRate>().ToListAsync();
    }
    
    public async Task<CurrentInterestRate?> GetItemAsync(Guid id)
    {
        var database = await Init(configuration.DatabasePath);
        return await database.GetAsync<CurrentInterestRate>(id);
    }
    
    public async Task SaveItemAsync(CurrentInterestRate item)
    {
        var database = await Init(configuration.DatabasePath);
        
        if (item.Id != Guid.Empty)
        {
            item.Id = Guid.NewGuid();
            await database.UpdateAsync(item);
        }
        
        await database.InsertAsync(item);
    }
}