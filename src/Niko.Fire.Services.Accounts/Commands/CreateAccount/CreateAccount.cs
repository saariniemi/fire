using MediatR;

namespace Niko.Fire.Services.Accounts.Commands;

public class CreateAccount : IRequest<CreateAccountResponse>
{
    public required string Name { get; set; }
}