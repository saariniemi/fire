using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Niko.Fire.Services.Accounts;

public static class ServiceCollectionExtensions
{
    public static void AddAccount(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
    }
}