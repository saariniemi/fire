using SQLite;

namespace Niko.Fire.Infrastructure;

public class Loan
{
    [PrimaryKey]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public decimal PrincipalAmount { get; set; }
    public decimal RemainingBalance { get; set; }
    public DateTime OriginationDate { get; set; }
    public DateTime MaturityDate { get; set; }
}