using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Niko.Fire.Loans;

public static class ServiceCollectionExtensions
{
    public static void AddLoan(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}