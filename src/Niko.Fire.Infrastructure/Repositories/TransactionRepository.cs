using Niko.Fire.Infrastructure.Constants;
using Niko.Fire.Infrastructure.Interfaces;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace Niko.Fire.Infrastructure;

public class TransactionRepository(IConfiguration configuration)
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
        await _database.CreateTableAsync<Transaction>();
        return _database;
    }
    
    public async Task SaveItemAsync(Transaction item)
    {
        var database = await Init(configuration.DatabasePath);
        
        if (item.Id != Guid.Empty)
        {
            item.Id = Guid.NewGuid();
            await database.UpdateWithChildrenAsync(item);
        }
        
        await database.InsertWithChildrenAsync(item, recursive: true);
    }
    
    public async Task<List<Transaction>> GetItemsAsync(IAccount account)
    {
        var database = await Init(configuration.DatabasePath);
        return await database.Table<Transaction>().Where(i => i.AccountId == account.Id).ToListAsync();
    }
}