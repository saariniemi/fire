using MediatR;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccountHandler(AccountRepository accountRepository) : IRequestHandler<DeleteAccount, DeleteAccountResponse>
{
    public async Task<DeleteAccountResponse> Handle(DeleteAccount request, CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetItemAsync(request.Id);

        if (account == null)
        {
            return new DeleteAccountResponse(request)
            {
                NumberOfRowsDeleted = 0,
                ErrorMessage = "Account does not exist",
            };
        }

        if (account.Name == request.Name)
        {
            return new DeleteAccountResponse(request)
            {
                NumberOfRowsDeleted = 0,
                ErrorMessage = "Name does not match"
            };
        }
        
        var result = await accountRepository.DeleteItemAsync(account);

        return new DeleteAccountResponse(request)
        {
            NumberOfRowsDeleted = result,
        };
    }
}