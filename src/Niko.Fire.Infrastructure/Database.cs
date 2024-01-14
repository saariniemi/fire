using SQLite;

namespace Niko.Fire.Infrastructure;

public class Database : SQLiteAsyncConnection
{
    public static async Task<Database> Create(IConfiguration configuration)
    {
        var database = new Database(configuration.DatabasePath, configuration.Flags);
        _ = await database.CreateTableAsync<Account>();
        return database;
    }
    
    public Database(string databasePath, bool storeDateTimeAsTicks = true) : base(databasePath, storeDateTimeAsTicks)
    {
    }

    public Database(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true) : base(databasePath, openFlags, storeDateTimeAsTicks)
    {
    }

    public Database(SQLiteConnectionString connectionString) : base(connectionString)
    {
    }
}