using MediatR;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccount : IRequest<DeleteAccountResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}