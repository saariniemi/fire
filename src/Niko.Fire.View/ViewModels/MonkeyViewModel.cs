using CommunityToolkit.Mvvm.ComponentModel;
using Niko.Fire.Services.Accounts;

namespace Niko.Fire.View.Views;

public class MonkeyViewModel : ObservableObject
{
    private readonly Account _account;

    public MonkeyViewModel()
    {
        _account = new Account();
    }

    public MonkeyViewModel(Account item)
    {
        _account = item;
    }

    public string Name => _account.Name;


}