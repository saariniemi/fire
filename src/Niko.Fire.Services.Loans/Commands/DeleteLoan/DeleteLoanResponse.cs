namespace Niko.Fire.Services.Loans.Commands;

public class DeleteLoanResponse(DeleteLoan request) : IResponse<DeleteLoan>
{
    public DeleteLoan Request => request;
    
    public int NumberOfRowsDeleted { get; set; }
}