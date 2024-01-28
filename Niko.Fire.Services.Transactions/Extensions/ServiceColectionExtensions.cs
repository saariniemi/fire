using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Niko.Fire.Services.Transactions.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddTransaction(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
    
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}