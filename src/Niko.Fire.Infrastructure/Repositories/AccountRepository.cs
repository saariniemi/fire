﻿using FluentValidation;
using Niko.Fire.Infrastructure.Constants;
using Niko.Fire.Infrastructure.Validators;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace Niko.Fire.Infrastructure;

public class AccountRepository(IConfiguration configuration)
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
        return _database;
    }

    public async Task<List<Account>> GetItemsAsync()
    {
        var database = await Init(configuration.DatabasePath);
        return await database.Table<Account>().ToListAsync();
    }
    
    public async Task<Account?> GetByNameAsync(string name)
    {
        var database = await Init(configuration.DatabasePath);
        return await database.Table<Account>().FirstOrDefaultAsync(a => a.Name == name);
    }

    public async Task<Account?> GetItemAsync(Guid id)
    {
        var database = await Init(configuration.DatabasePath);
        return await database.Table<Account>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    // TODO: REMOVE RETURN INT
    public async Task<int> SaveItemAsync(Account item)
    {
        var database = await Init(configuration.DatabasePath);

        var accountValidator = new AccountValidator(this);
        _ = await accountValidator.ValidateAsync(item, options => options.ThrowOnFailures());
        
        if (item.Id != Guid.Empty)
        {
            item.Id = Guid.NewGuid();
            return await database.UpdateAsync(item);
        }

        item.Id = Guid.NewGuid();
        return await database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(Account item)
    {
        var database = await Init(configuration.DatabasePath);
        
        return await database.DeleteAsync(item);
    }
}