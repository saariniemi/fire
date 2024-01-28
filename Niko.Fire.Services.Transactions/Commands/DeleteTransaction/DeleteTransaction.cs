using MediatR;

namespace Niko.Fire.Services.Transactions.Commands.DeleteTransaction;

public class DeleteTransaction : IRequest<DeleteTransactionResponse>
{
    
}

public class DeleteTransactionHandler : IRequestHandler<DeleteTransaction, DeleteTransactionResponse>
{
    public Task<DeleteTransactionResponse> Handle(DeleteTransaction request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class DeleteTransactionResponse(DeleteTransaction request) : IResponse<DeleteTransaction>
{
    public DeleteTransaction Request { get; } = request;
}