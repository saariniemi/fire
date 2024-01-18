using MediatR;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccount : IRequest<CreateAccountResponse>
{
    public string Name { get; set; }
}