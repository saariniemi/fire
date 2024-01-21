using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Loans.Commands;

public class CreateLoanWithFixedRateValidator : AbstractValidator<CreateLoanWithFixedRate>
{
    private static readonly DateTime BeginningOfNineteenthCentury = new DateTime(1900, 1, 1);

    public CreateLoanWithFixedRateValidator()
    {
        RuleFor(x => x).NotNull();
        
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(1, 50);
        
        RuleFor(x => x.PrincipalAmount).GreaterThan(0);
        
        RuleFor(x => x.OriginationDate).GreaterThanOrEqualTo(BeginningOfNineteenthCentury).WithMessage("Invalid origination date");
        
        RuleFor(x => x.Rate).GreaterThan(0);
        RuleFor(x => x.PeriodInYears).GreaterThan(0);
        RuleFor(x => x.Amortization).GreaterThanOrEqualTo(0);
    }

    protected override void RaiseValidationException(ValidationContext<CreateLoanWithFixedRate> context, ValidationResult result)
    {
        throw new CreateLoanWithFixedRateValidationException(result.Errors);
    }
}