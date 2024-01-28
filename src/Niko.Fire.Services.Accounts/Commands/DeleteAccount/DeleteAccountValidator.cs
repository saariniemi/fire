using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Accounts.Commands;

public class DeleteAccountValidator : AbstractValidator<(DeleteAccount request, Infrastructure.Account? accountToBeDeleted)>
{
    public DeleteAccountValidator()
    {
        RuleFor(x => x.request).NotNull();
        RuleFor(x => x.accountToBeDeleted).NotNull().WithMessage("Account does not exist");
        RuleFor(x => x.request.Name).Equal(x => x.accountToBeDeleted!.Name).WithMessage("Invalid name");
    }

    protected override void RaiseValidationException(ValidationContext<(DeleteAccount request, Infrastructure.Account? accountToBeDeleted)> context, ValidationResult result)
    {
        throw new DeleteAccountException(result.Errors);
    }
}