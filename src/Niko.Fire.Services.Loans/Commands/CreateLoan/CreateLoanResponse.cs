namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanResponse(CreateLoan request) : IResponse<CreateLoan>
{
    public CreateLoan Request => request;

    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
}

