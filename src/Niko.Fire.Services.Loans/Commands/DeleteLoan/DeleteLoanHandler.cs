using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Loans.Commands;

public class DeleteLoanHandler(LoanRepository loanRepository, DeleteLoanValidator validator) : IRequestHandler<DeleteLoan, DeleteLoanResponse>
{
    public async Task<DeleteLoanResponse> Handle(DeleteLoan request, CancellationToken cancellationToken)
    {
        if (loanRepository == null)
        {
            throw new Exception("!");
        }
        
        if (validator == null)
        {
            throw new Exception("!");
        }
        
        var loanToBeDeleted = await loanRepository.GetItemAsync(request.Id);
        
        if (loanToBeDeleted == null)
        {
            throw new Exception("!");
        }
        
        _ = await validator.ValidateAsync((request, loanToBeDeleted), options => options.ThrowOnFailures(), cancellationToken);
        
        var result = await loanRepository.DeleteItemAsync(loanToBeDeleted!);

        return new DeleteLoanResponse(request)
        {
            NumberOfRowsDeleted = result,
        };
    }
}