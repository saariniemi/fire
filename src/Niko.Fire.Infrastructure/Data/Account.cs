using SQLite;

namespace Niko.Fire.Infrastructure;

public class Account
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}