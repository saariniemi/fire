using System.Data.SqlTypes;
using MediatR;

namespace Niko.Fire.Loans.Commands;

public class CreateLoan : IRequest<CreateLoanResponse>
{
    public required string Name { get; set; }
    public required decimal PrincipalAmount { get; set; }
    public required decimal RemainingBalance { get; set; }
    public required DateTime OriginationDate { get; set; }
    public required DateTime MaturityDate { get; set; }
}