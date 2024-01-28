using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Accounts.Commands;

public class CreateAccountValidator : AbstractValidator<CreateAccount>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(1, 50);
    }

    protected override void RaiseValidationException(ValidationContext<CreateAccount> context, ValidationResult result)
    {
        throw new CreateAccountValidationException(result.Errors);
    }
}