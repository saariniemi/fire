using FluentValidation.Results;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccountResponse(DeleteAccount request) : IResponse<DeleteAccount>
{
    public DeleteAccount Request => request;
    
    public int NumberOfRowsDeleted { get; set; }
}