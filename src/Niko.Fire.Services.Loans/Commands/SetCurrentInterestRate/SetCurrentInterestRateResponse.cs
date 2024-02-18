namespace Niko.Fire.Services.Loans.Commands;

public class SetCurrentInterestRateResponse(SetCurrentInterestRate request) : IResponse<SetCurrentInterestRate>
{
    public SetCurrentInterestRate Request => request;

    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
}

