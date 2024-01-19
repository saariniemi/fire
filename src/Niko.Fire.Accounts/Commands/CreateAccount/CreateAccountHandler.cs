using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Validators;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccountHandler(AccountRepository accountRepository, CreateAccountValidator validator) : IRequestHandler<CreateAccount, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccount request, CancellationToken cancellationToken)
    {
        _ = await validator.ValidateAsync(request, cancellationToken);

        var account = new Account
        {
            Name = request.Name
        };
        
        var result = await accountRepository.SaveItemAsync(account);

        return new CreateAccountResponse(request)
        {
            Id = account.Id
        };
    }
}