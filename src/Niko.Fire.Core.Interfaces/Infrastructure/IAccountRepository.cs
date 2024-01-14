namespace Niko.Fire.Core.Interfaces;

public interface IAccountRepository
{
    async Task<int> SaveItemAsync(Account item)
}