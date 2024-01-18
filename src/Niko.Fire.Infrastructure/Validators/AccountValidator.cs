using FluentValidation;

namespace Niko.Fire.Infrastructure.Validators;

public class AccountValidator : AbstractValidator<Account>
{
    private readonly AccountRepository _accountRepository;

    public AccountValidator(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).MustAsync(UniqueName).WithMessage("Name must be unique");
        return;

        async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByNameAsync(name);
            return account == null;
        }
    }
}