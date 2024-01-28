using MediatR;

namespace Niko.Fire.Services.Accounts.Requests;

public class Account
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class GetAccount : IRequest<Account>
{
    public Guid Id { get; set; }
}