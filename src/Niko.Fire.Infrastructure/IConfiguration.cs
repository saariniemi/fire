namespace Niko.Fire.Infrastructure;

public interface IConfiguration
{
    const string DatabaseFilename = "LocalStorage.db3";

    SQLite.SQLiteOpenFlags Flags =>
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    string DatabasePath { get; }
}