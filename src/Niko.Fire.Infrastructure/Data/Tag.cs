using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Niko.Fire.Infrastructure;

public class Tag
{
    [PrimaryKey]
    public string Name { get; set; }
}