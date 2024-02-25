using MediatR;
using Niko.Fire.Infrastructure.Interfaces;
using Niko.Fire.Services.Accounts;

namespace Niko.Fire.Services.Transactions.Commands;

public class CreateStatement : IRequest<CreateStatementResponse>
{
    public required IAccount Account { get; set; }
    public required decimal Statement { get; set; }
    public required DateTime Date { get; set; }
}