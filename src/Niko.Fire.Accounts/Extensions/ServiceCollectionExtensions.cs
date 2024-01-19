using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Niko.Fire.Accounts.Commands;

namespace Niko.Fire.Accounts;

public static class ServiceCollectionExtensions
{
    public static void AddAccount(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}