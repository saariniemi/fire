using FluentValidation;

namespace Niko.Fire.Infrastructure.Validators;

public class AccountValidator : AbstractValidator<Account>
{
    public AccountValidator(AccountRepository accountRepository)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).MustAsync(UniqueName).WithMessage("Name must be unique");
        return;

        async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            var account = await accountRepository.GetByNameAsync(name);
            return account == null;
        }
    }
}