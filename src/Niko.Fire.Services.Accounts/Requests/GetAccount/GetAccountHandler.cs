using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Accounts.Requests;

public class GetAccountHandler(AccountRepository accountRepository) : IRequestHandler<GetAccount, Account>
{
    public async Task<Account> Handle(GetAccount request, CancellationToken cancellationToken)
    {
        var result = await accountRepository.GetItemAsync(request.Id);

        if (result == null)
        {
            throw new Exception("ADD VALIDATION"); // TODO: NIKO ADD VALIDATION
        }
        
        return new Account()
        {
            Id = result.Id,
            Name = result.Name
        };
    }
}