using MediatR;

namespace Niko.Fire.Services.Accounts.Requests;

public class GetAccount : IRequest<Account>
{
    public Guid Id { get; set; }
}