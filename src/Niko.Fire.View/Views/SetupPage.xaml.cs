using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using Niko.Fire.View.Models;
using Niko.Fire.View.ViewModels;

namespace Niko.Fire.View.Views;

public partial class SetupPage: ContentPage
{
    // public SetupPage(AccountsViewModel viewModel)
    // {
    //     
    //     InitializeComponent();
    //
    //     BindingContext = viewModel;
    //
    //
    //     //DataContext = Ioc.Default.GetRequiredService<SubredditWidgetViewModel>();
    //
    // }
    
    public SetupPage(LoansViewModel viewModel)
    {
        
        InitializeComponent();

        BindingContext = viewModel;


        //DataContext = Ioc.Default.GetRequiredService<SubredditWidgetViewModel>();

    }
}

