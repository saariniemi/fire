using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanHandler(LoanRepository loanRepository) : IRequestHandler<CreateLoan, CreateLoanResponse>
{
    public async Task<CreateLoanResponse> Handle(CreateLoan request, CancellationToken cancellationToken)
    {
        var loan = new Infrastructure.Loan()
        {
            Name = request.Name
        };
        
        await loanRepository.SaveItemAsync(loan);

        return new CreateLoanResponse(request)
        {
            Id = loan.Id
        };
    }
}