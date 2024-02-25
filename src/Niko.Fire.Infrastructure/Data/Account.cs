using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Niko.Fire.Infrastructure;

public class Account
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    [ForeignKey(typeof(Loan))]
    public Guid LoanId { get; set; }
    
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public Loan? Loan { get; set; }
}