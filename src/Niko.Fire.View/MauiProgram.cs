﻿using MediatR;
using Microsoft.Extensions.Logging;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Infrastructure;
using Niko.Fire.Services.Loans;
using Niko.Fire.Services.Transactions.Extensions;
using Niko.Fire.View.ViewModels;
using Niko.Fire.View.Views;
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

        // Setup Niko.Fire.Services
        builder.Services.AddAccount();
        builder.Services.AddLoan();
        builder.Services.AddTransaction();
        
        // Setup Niko.Fire.Infrastructure
        builder.Services.AddSingleton<Infrastructure.IConfiguration>(new InfrastructureConfiguration());
        builder.Services.AddDatabase();

        builder.Services.AddTransient<MainPage>();
        
        // builder.Services.AddSingleton<AccountViewModel>();
        //builder.Services.AddSingleton<MyViewModel>();

        builder.Services.AddSingleton<AccountsViewModel>();
        builder.Services.AddSingleton<LoansViewModel>();

        builder.Services.AddTransient<TransactionsViewModel>();

        builder.Services.AddTransient<AccountTransactionPage>();
        builder.Services.AddTransient<SetupPage>();
        builder.Services.AddTransient<SetupPage_Accounts>();
        builder.Services.AddTransient<SetupPage_Loans>();

        //builder.Services.AddTransient<SubredditWidgetViewModel>();

        return builder.Build();
    }
}