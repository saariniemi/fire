namespace Niko.Fire.Services.Transactions.Commands;

public class CreateStatementResponse(CreateStatement request) : IResponse<CreateStatement>
{
    public CreateStatement Request { get; } = request;
    public Guid Id { get; set; }
}