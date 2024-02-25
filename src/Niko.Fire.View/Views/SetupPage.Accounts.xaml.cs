using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niko.Fire.View.ViewModels;

namespace Niko.Fire.View.Views;

public partial class SetupPage_Accounts : ContentView
{
    public SetupPage_Accounts()
    {
        InitializeComponent();
        BindingContext = Application.Current.Handler.MauiContext.Services.GetService<AccountsViewModel>();
    }
}