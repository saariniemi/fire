using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Accounts.Requests;

public class GetAccountsHandler(AccountRepository accountRepository) : IRequestHandler<GetAccounts, IEnumerable<Account>>
{
    public async Task<IEnumerable<Account>> Handle(GetAccounts request, CancellationToken cancellationToken)
    {
        var result = await accountRepository.GetItemsAsync();
        return result.Select(account => new Account 
        { 
            Id = account.Id,
            Name = account.Name 
        });
    }
}