using Microsoft.Extensions.DependencyInjection;

namespace Niko.Fire.Infrastructure;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(Database.Create(configuration));
        services.AddSingleton<AccountRepository>();

        return services;
    }
}