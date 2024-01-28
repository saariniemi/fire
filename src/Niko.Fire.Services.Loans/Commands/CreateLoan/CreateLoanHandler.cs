using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;
using Niko.Fire.Infrastructure.Validators;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanHandler(LoanRepository loanRepository, CreateLoanValidator validator) : IRequestHandler<CreateLoan, CreateLoanResponse>
{
    public async Task<CreateLoanResponse> Handle(CreateLoan request, CancellationToken cancellationToken)
    {
        _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken);

        var loan = new Loan
        {
            Name = request.Name,
            PrincipalAmount = request.PrincipalAmount,
            RemainingBalance = request.RemainingBalance,
            OriginationDate = request.OriginationDate,
            MaturityDate = request.MaturityDate,
            Account = new Account
            {
                Name = request.Name
            }
        };
        
        await loanRepository.SaveItemAsync(loan);

        return new CreateLoanResponse(request)
        {
            Id = loan.Id,
            AccountId = loan.Account.Id
        };
    }
}
