using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Accounts.Commands;

public class CreateAccountHandler(AccountRepository accountRepository, CreateAccountValidator validator) : IRequestHandler<CreateAccount, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccount request, CancellationToken cancellationToken)
    {
        _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken);

        var account = new Infrastructure.Account
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