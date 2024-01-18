using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Validators;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccountHandler(AccountRepository accountRepository) : IRequestHandler<CreateAccount, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccount request, CancellationToken cancellationToken)
    {
        var accountValidator = new AccountValidator(accountRepository);
        var createAccountValidator = new CreateAccountValidator();
        
        var createAccountValidationResult = await createAccountValidator.ValidateAsync(request, cancellationToken);
        if (!createAccountValidationResult.IsValid)
        {
            return new CreateAccountResponse(request)
            {
                ValidationResult = createAccountValidationResult
            };
        }

        var account = new Account
        {
            Name = request.Name
        };

        var accountValidationResult = await accountValidator.ValidateAsync(account, cancellationToken);
        if (!accountValidationResult.IsValid)
        {
            return new CreateAccountResponse(request)
            {
                ValidationResult = accountValidationResult
            };
        }
        
        var result = await accountRepository.SaveItemAsync(account);

        return new CreateAccountResponse(request)
        {
            Id = account.Id
        };
    }
}