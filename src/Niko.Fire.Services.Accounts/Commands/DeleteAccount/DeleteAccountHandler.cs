using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Accounts.Commands;

public class DeleteAccountHandler(AccountRepository accountRepository, DeleteAccountValidator validator) : IRequestHandler<DeleteAccount, DeleteAccountResponse>
{
    public async Task<DeleteAccountResponse> Handle(DeleteAccount request, CancellationToken cancellationToken)
    {
        var accountToBeDeleted = await accountRepository.GetItemAsync(request.Id);
        _ = await validator.ValidateAsync((request, accountToBeDeleted), options => options.ThrowOnFailures(), cancellationToken);
        
        var result = await accountRepository.DeleteItemAsync(accountToBeDeleted!);

        return new DeleteAccountResponse(request)
        {
            NumberOfRowsDeleted = result,
        };
    }
}