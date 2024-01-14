using SQLite;

namespace Niko.Fire.Infrastructure;

public class Account
{
    [PrimaryKey, AutoIncrement, Column("_id")]
    public Guid Id { get; set; }
    
    [MaxLength(100), Unique]
    public string Name { get; set; }
}