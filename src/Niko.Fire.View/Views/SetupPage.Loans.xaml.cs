using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niko.Fire.View.ViewModels;

namespace Niko.Fire.View.Views;

public partial class SetupPage_Loans : ContentView
{
    public SetupPage_Loans()
    {
        InitializeComponent();
        BindingContext = Application.Current.Handler.MauiContext.Services.GetService<LoansViewModel>();
    }
}