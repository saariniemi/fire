using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Loans.Commands;

public class CreateLoanWithFixedRateHandler(ISender sender, LoanRepository loanRepository, CreateLoanWithFixedRateValidator validator) 
    : IRequestHandler<CreateLoanWithFixedRate, CreateLoanWithFixedRateResponse>
{
    public async Task<CreateLoanWithFixedRateResponse> Handle(CreateLoanWithFixedRate request, CancellationToken cancellationToken)
    {
        _ = await validator.ValidateAsync(request, options => options.ThrowOnFailures(), cancellationToken);
        
        var createLoan = new CreateLoan
        {
            Name = request.Name,
            PrincipalAmount = request.PrincipalAmount,
            RemainingBalance = RemainingBalance(),
            OriginationDate = request.OriginationDate,
            MaturityDate = MaturityDate()
        };

        var createLoanResponse = await sender.Send(createLoan, cancellationToken);
        
        return new CreateLoanWithFixedRateResponse(request)
        {
            Id = createLoanResponse.Id,
            
        };
        
        decimal RemainingBalance()
        {
            return request.PrincipalAmount - request.Amortization * (decimal)request.PeriodInYears;
        }
        
        DateTime MaturityDate()
        {
            return request.PeriodInYears % 1 != 0
                ? request.OriginationDate.AddYears((int)request.PeriodInYears)
                : request.OriginationDate.AddMonths((int)(12f * request.PeriodInYears));
        }
        
    }
}
