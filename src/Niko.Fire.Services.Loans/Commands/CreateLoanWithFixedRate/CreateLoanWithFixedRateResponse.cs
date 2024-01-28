namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanWithFixedRateResponse(CreateLoanWithFixedRate request) : IResponse<CreateLoanWithFixedRate>
{
    public CreateLoanWithFixedRate Request => request;

    public Guid Id { get; set; }
}

