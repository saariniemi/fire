using FluentValidation;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccountValidator : AbstractValidator<CreateAccount>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(1, 50);
    }
}