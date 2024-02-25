using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Niko.Fire.View.ViewModels;

namespace Niko.Fire.View.Views;

public partial class AccountTransactionPage : ContentPage
{
    public AccountTransactionPage(TransactionsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void MenuItem_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
}