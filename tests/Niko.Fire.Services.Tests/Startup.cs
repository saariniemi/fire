using Microsoft.Extensions.DependencyInjection;
using Niko.Fire.Accounts;
using Niko.Fire.Loans;
using Niko.Fire.Infrastructure;

namespace Niko.Fire.Services.Tests;

public class Startup
{
    private const string Path = "./LocalStorage.db3";
    
    public void ConfigureServices(IServiceCollection services)
    {
        // Setup Niko.Fire.Accounts
        services.AddAccount();
        services.AddLoan();
        
        // Setup Niko.Fire.Infrastructure
        services.AddSingleton<Infrastructure.IConfiguration>(new InfrastructureConfiguration());
        services.AddDatabase();
    }
    
    private class InfrastructureConfiguration : IConfiguration
    {
        public string DatabasePath => Path;
    }
}