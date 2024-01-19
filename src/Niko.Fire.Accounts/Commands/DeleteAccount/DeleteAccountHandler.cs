using FluentValidation;
using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccountHandler(AccountRepository accountRepository, DeleteAccountValidator validator) : IRequestHandler<DeleteAccount, DeleteAccountResponse>
{
    public async Task<DeleteAccountResponse> Handle(DeleteAccount request, CancellationToken cancellationToken)
    {
        var accountToBeDeleted = await accountRepository.GetItemAsync(request.Id);
        _ = await validator.ValidateAsync((request, accountToBeDeleted), cancellationToken);
        
        var result = await accountRepository.DeleteItemAsync(accountToBeDeleted!);

        return new DeleteAccountResponse(request)
        {
            NumberOfRowsDeleted = result,
        };
    }
}