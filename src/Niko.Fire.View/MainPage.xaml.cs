using System.Net.NetworkInformation;
using MediatR;
using Niko.Fire.View.ViewModels;

namespace Niko.Fire.View;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(AccountViewModel accountViewModel)
    {
        InitializeComponent();
        BindingContext = accountViewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}