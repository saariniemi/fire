using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Niko.Fire.Infrastructure;

public class CurrentInterestRate
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    
    public decimal PrincipalAmount { get; set; }
    public decimal RemainingBalance { get; set; }
    public DateTime OriginationDate { get; set; }
    public DateTime MaturityDate { get; set; }

    [ForeignKey(typeof(Loan))]
    public Guid LoanId { get; set; }

    [ManyToOne]
    public Loan Loan { get; set; }
}