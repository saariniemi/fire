namespace Niko.Fire.Services.Transactions.Commands.CreateTransaction;

public class CreateTransactionResponse(CreateTransaction request) : IResponse<CreateTransaction>
{
    public CreateTransaction Request { get; } = request;
    public Guid Id { get; set; }
}