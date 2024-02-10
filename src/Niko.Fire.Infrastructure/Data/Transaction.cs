using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Niko.Fire.Infrastructure;

public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    
    [TextBlob("TagBlob")]
    public List<string> Tags { get; set; }
    
    public string TagBlob { get; set; } // serialized 


    [ForeignKey(typeof(Account))]
    public Guid AccountId { get; set; }

    [ManyToOne]
    public Account Account { get; set; }
    
}