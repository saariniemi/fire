using MediatR;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoan : IRequest<CreateLoanResponse>
{
    public required string Name { get; set; }
}