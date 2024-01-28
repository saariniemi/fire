using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanValidator : AbstractValidator<CreateLoan>
{
    private static readonly DateTime BeginningOfNineteenthCentury = new DateTime(1900, 1, 1);

    public CreateLoanValidator()
    {
        RuleFor(x => x).NotNull();
        
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(1, 50);
        
        RuleFor(x => x.PrincipalAmount).GreaterThan(0);
        
        RuleFor(x => x.RemainingBalance).GreaterThanOrEqualTo(0);
        
        RuleFor(x => x.OriginationDate).GreaterThanOrEqualTo(BeginningOfNineteenthCentury).WithMessage("Invalid origination date");;
        
        RuleFor(x => x.MaturityDate).GreaterThanOrEqualTo(BeginningOfNineteenthCentury).WithMessage("Invalid origination date");;
        RuleFor(x => x).Must(y => y.OriginationDate < y.MaturityDate).WithMessage("Invalid maturity date");
    }

    protected override void RaiseValidationException(ValidationContext<CreateLoan> context, ValidationResult result)
    {
        throw new CreateLoanValidationException(result.Errors);
    }
}