using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;

namespace Niko.Fire.Infrastructure;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<AccountRepository>();
        services.AddSingleton<LoanRepository>();
        
        return services;
    }
}