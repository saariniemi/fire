namespace Niko.Fire.View;

public class InfrastructureConfiguration : Niko.Fire.Infrastructure.IConfiguration
{
    public string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, Niko.Fire.Infrastructure.IConfiguration.DatabaseFilename);
}