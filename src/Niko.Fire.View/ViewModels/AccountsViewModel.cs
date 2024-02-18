using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Accounts.Commands;
using Niko.Fire.Services.Accounts.Requests;

namespace Niko.Fire.View.Views;

public sealed class AccountsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ICommand CreateAccountCommand { get; }
    
    public ObservableCollection<MonkeyViewModel> Monkeys { get; private set; } = [];

    private readonly IMediator _mediator;
    public AccountsViewModel(IMediator mediator)
    {
        Task.Run(async () =>
        {
            var accounts = await mediator.Send(new GetAccounts());
            Monkeys = new ObservableCollection<MonkeyViewModel>(accounts.Select(a => new MonkeyViewModel(a)));
            OnPropertyChanged(nameof(Monkeys));
        });
        
        CreateAccountCommand = new AsyncRelayCommand(CreateAccount);

        _mediator = mediator;
    }

    private async Task CreateAccount()
    {
        var newAccountName = await Application.Current.MainPage.DisplayPromptAsync("Create a account", "Enter your account name", maxLength: 30, keyboard: Keyboard.Plain);
        
        var command = new CreateAccount
        {
            Name = newAccountName
        };
        
        var createAccountResponse = await _mediator.Send(command);

        if (createAccountResponse.Id != Guid.Empty)
        {
            var account = await _mediator.Send(new GetAccount { Id = createAccountResponse.Id });
            Monkeys.Add(new MonkeyViewModel(account));
            OnPropertyChanged(nameof(Monkeys));
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

