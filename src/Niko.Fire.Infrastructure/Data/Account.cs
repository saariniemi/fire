using SQLite;

namespace Niko.Fire.Infrastructure;

public class Account
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}