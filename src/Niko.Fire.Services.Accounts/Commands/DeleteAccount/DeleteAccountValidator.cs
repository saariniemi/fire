using FluentValidation;
using FluentValidation.Results;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Accounts.Commands;

public class DeleteAccountValidator : AbstractValidator<(DeleteAccount request, Account? accountToBeDeleted)>
{
    public DeleteAccountValidator()
    {
        RuleFor(x => x.request).NotNull();
        RuleFor(x => x.accountToBeDeleted).NotNull().WithMessage("Account does not exist");
        RuleFor(x => x.request.Name).Equal(x => x.accountToBeDeleted!.Name).WithMessage("Invalid name");
    }

    protected override void RaiseValidationException(ValidationContext<(DeleteAccount request, Account? accountToBeDeleted)> context, ValidationResult result)
    {
        throw new DeleteAccountException(result.Errors);
    }
}