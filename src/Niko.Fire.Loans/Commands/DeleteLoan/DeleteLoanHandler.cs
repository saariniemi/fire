using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Loans.Commands;

public class DeleteLoanHandler(LoanRepository loanRepository, DeleteLoanValidator validator) : IRequestHandler<DeleteLoan, DeleteLoanResponse>
{
    public async Task<DeleteLoanResponse> Handle(DeleteLoan request, CancellationToken cancellationToken)
    {
        var accountToBeDeleted = await loanRepository.GetItemAsync(request.Id);
        _ = await validator.ValidateAsync((request, accountToBeDeleted), options => options.ThrowOnFailures(), cancellationToken);
        
        var result = await loanRepository.DeleteItemAsync(accountToBeDeleted!);

        return new DeleteLoanResponse(request)
        {
            NumberOfRowsDeleted = result,
        };
    }
}