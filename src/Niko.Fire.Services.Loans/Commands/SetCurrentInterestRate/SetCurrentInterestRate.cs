using System.Data.SqlTypes;
using MediatR;

namespace Niko.Fire.Services.Loans.Commands;

public class SetCurrentInterestRate : IRequest<SetCurrentInterestRateResponse>
{
    public required Guid LoanId { get; set; }
    public required decimal PrincipalAmount { get; set; }
    public required decimal RemainingBalance { get; set; }
    public required DateTime OriginationDate { get; set; }
    public required DateTime MaturityDate { get; set; }
}