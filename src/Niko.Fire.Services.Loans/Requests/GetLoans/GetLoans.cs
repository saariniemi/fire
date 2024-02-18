using MediatR;

namespace Niko.Fire.Services.Loans.Requests;

public class GetLoans : IRequest<IEnumerable<Loan>>
{
    
}