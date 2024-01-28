using FluentValidation;
using FluentValidation.Results;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Loans.Commands;

public class DeleteLoanValidator : AbstractValidator<(DeleteLoan request, Loan? loanToBeDeleted)>
{
    public DeleteLoanValidator()
    {
        RuleFor(x => x.request).NotNull();
        RuleFor(x => x.loanToBeDeleted).NotNull().WithMessage("Loan does not exist");
        RuleFor(x => x.request.Name).Equal(x => x.loanToBeDeleted.Name).WithMessage("Invalid name");
    }

    protected override void RaiseValidationException(ValidationContext<(DeleteLoan request, Loan? loanToBeDeleted)> context, ValidationResult result)
    {
        throw new DeleteLoanException(result.Errors);
    }
}