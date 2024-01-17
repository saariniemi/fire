using Microsoft.Extensions.Logging;
using Niko.Fire.Accounts;
using Niko.Fire.Infrastructure;
using Niko.Fire.View.ViewModels;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Niko.Fire.View;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));

        // Setup Niko.Fire.Infrastructure
        builder.Services.AddSingleton<Infrastructure.IConfiguration>(new InfrastructureConfiguration());
        builder.Services.AddDatabase();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AccountViewModel>();

        return builder.Build();
    }
}