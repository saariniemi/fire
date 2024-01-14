using System.Net.NetworkInformation;
using MediatR;
using Niko.Fire.Accounts.Commands;
using Niko.Fire.Accounts.Responses;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Handlers;

public class CreateAccountHandler(AccountRepository accountRepository) : IRequestHandler<CreateAccount, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccount request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            Name = request.Name
        };
        
        var result = await accountRepository.SaveItemAsync(account);

        var response = new CreateAccountResponse
        {
            Id = account.Id
        };
        
        return await Task.FromResult(response);
    }
}