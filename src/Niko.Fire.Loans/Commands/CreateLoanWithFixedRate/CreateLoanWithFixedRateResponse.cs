using FluentValidation.Results;
using Niko.Fire.Loans;

namespace Niko.Fire.Loans.Commands;

public class CreateLoanWithFixedRateResponse(CreateLoanWithFixedRate request) : IResponse<CreateLoanWithFixedRate>
{
    public CreateLoanWithFixedRate Request => request;

    public Guid Id { get; set; }
}

