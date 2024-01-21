using Niko.Fire.Infrastructure.Constants;
using SQLite;

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
        await _database.CreateTableAsync<Loan>();
        return _database;
    }
    
    public async Task<object> SaveItemAsync(Loan item)
    {
        var database = await Init(configuration.DatabasePath);
        
        if (item.Id != Guid.Empty)
        {
            item.Id = Guid.NewGuid();
            return await database.UpdateAsync(item);
        }

        item.Id = Guid.NewGuid();
        return await database.InsertAsync(item);
    }
}