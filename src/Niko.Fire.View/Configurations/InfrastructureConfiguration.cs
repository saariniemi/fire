using Niko.Fire.Infrastructure;

namespace Niko.Fire.View;

public class InfrastructureConfiguration : IConfiguration
{
    private const string DatabaseFilename = "LocalStorage.db3";
    
    public string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}