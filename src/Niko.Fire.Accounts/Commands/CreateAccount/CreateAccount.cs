using MediatR;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccount : IRequest<CreateAccountResponse>
{
    public required string Name { get; set; }
}