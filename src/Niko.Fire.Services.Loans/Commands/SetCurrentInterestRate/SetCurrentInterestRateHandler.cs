using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Validators;

namespace Niko.Fire.Services.Loans.Commands;

public class SetCurrentInterestRateHandler(CurrentInterestRateRepository currentInterestRateRepository, LoanRepository loanRepository, SetCurrentInterestRateValidator validator) : IRequestHandler<SetCurrentInterestRate, SetCurrentInterestRateResponse>
{
    public async Task<SetCurrentInterestRateResponse> Handle(SetCurrentInterestRate request, CancellationToken cancellationToken)
    {
        _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken);

        var loan = new Infrastructure.CurrentInterestRate
        {
            Loan = await loanRepository.GetItemAsync(request.LoanId) ?? throw new Exception("!"),
            PrincipalAmount = request.PrincipalAmount,
            RemainingBalance = request.RemainingBalance,
            OriginationDate = request.OriginationDate,
            MaturityDate = request.MaturityDate
        };
        
        await currentInterestRateRepository.SaveItemAsync(loan);

        return new SetCurrentInterestRateResponse(request)
        {
            Id = loan.Id,
            AccountId = loan.Id
        };
    }
}
