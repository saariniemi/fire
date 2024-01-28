using Niko.Fire.Infrastructure.Constants;
using SQLite;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync.Extensions;

namespace Niko.Fire.Infrastructure;

public class LoanRepository(IConfiguration configuration)
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
        await _database.CreateTableAsync<Account>();
        await _database.CreateTableAsync<Loan>();
        return _database;
    }
    
    public async Task<Loan?> GetItemAsync(Guid id)
    {
        var database = await Init(configuration.DatabasePath);
        return await database.GetAsync<Loan>(id);
    }
    
    public async Task SaveItemAsync(Loan item)
    {
        var database = await Init(configuration.DatabasePath);
        
        if (item.Id != Guid.Empty)
        {
            item.Id = Guid.NewGuid();
            await database.UpdateWithChildrenAsync(item);
        }
        
        await database.InsertWithChildrenAsync(item, recursive: true);
    }
    
    public async Task<int> DeleteItemAsync(Loan item)
    {
        var database = await Init(configuration.DatabasePath);
        
        return await database.DeleteAsync(item);
    }
}