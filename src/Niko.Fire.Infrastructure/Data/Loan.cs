using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Niko.Fire.Infrastructure;

public class Loan
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    [ForeignKey(typeof(Account))]
    public Guid AccountId { get; set; }
    
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public Account Account { get; set; }
}