using SQLite;

namespace Niko.Fire.Infrastructure;

public class AccountRepository(Database database)
{
    public async Task<List<Account>> GetItemsAsync()
    {
        return await database.Table<Account>().ToListAsync();
    }

    public async Task<Account> GetItemAsync(Guid id)
    {
        return await database.Table<Account>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Account item)
    {
        if (item.Id != Guid.Empty)
        {
            return await database.UpdateAsync(item);
        }
        else
        {
            return await database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(Account item)
    {
        return await database.DeleteAsync(item);
    }
}