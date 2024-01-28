using MediatR;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanWithFixedRate : IRequest<CreateLoanWithFixedRateResponse>
{
    public static class Periods
    {
        public const float ThreeMonths = 0.25f;
        public const int OneYear = 1;
    }

    public required string Name { get; set; }
    public required decimal PrincipalAmount { get; set; }
    public required DateTime OriginationDate { get; set; }
    public required decimal Rate { get; set; }
    public required float PeriodInYears { get; set; } = Periods.ThreeMonths;
    public required decimal Amortization { get; set; }
}