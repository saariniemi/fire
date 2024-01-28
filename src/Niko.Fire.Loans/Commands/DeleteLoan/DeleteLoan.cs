using MediatR;

namespace Niko.Fire.Loans.Commands;

public class DeleteLoan : IRequest<DeleteLoanResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}