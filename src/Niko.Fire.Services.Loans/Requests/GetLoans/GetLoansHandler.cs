using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Loans.Requests;

public class GetLoansHandler(LoanRepository loanRepository) : IRequestHandler<GetLoans, IEnumerable<Loan>>
{
    public async Task<IEnumerable<Loan>> Handle(GetLoans request, CancellationToken cancellationToken)
    {
        var result = await loanRepository.GetItemsAsync();
        return result.Select(loan => new Loan 
        {
            Id = loan.Id,
            Name = loan.Name
        });
    }
}