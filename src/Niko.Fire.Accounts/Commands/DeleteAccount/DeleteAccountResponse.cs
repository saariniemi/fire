using FluentValidation.Results;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccountResponse(DeleteAccount request) : IResponse<DeleteAccount>
{
    public DeleteAccount Request => request;
    
    public ValidationResult? ValidationResult { get; }

    public int NumberOfRowsDeleted { get; set; }
    public string? ErrorMessage { get; set; }
}