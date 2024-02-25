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

namespace Niko.Fire.View.ViewModels;

public sealed class AccountsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ICommand CreateAccountCommand { get; }
    public IAsyncRelayCommand<Account> DeleteAccountCommand { get; }
    
    public ObservableCollection<Account> Accounts { get; private set; } = [];

    private readonly IMediator _mediator;
    public AccountsViewModel(IMediator mediator)
    {
        Task.Run(async () =>
        {
            var accounts = await mediator.Send(new GetAccounts());
            Accounts = new ObservableCollection<Account>(accounts.Where(a => a.LoanId == Guid.Empty));
            OnPropertyChanged(nameof(Accounts));
        });
        
        CreateAccountCommand = new AsyncRelayCommand(CreateAccount);
        DeleteAccountCommand = new AsyncRelayCommand<Account>(DeleteAccount);

        _mediator = mediator;
    }

    private async Task CreateAccount()
    {
        var newAccountName = await Application.Current.MainPage.DisplayPromptAsync("Create a account", "Enter your account name", maxLength: 30, keyboard: Keyboard.Plain);
        
        if (newAccountName == null)
        {
            return;
        } 
        
        var command = new CreateAccount
        {
            Name = newAccountName
        };
        
        var createAccountResponse = await _mediator.Send(command);
        
        if (createAccountResponse.Id != Guid.Empty)
        {
            var account = await _mediator.Send(new GetAccount { Id = createAccountResponse.Id });
            Accounts.Add(account);
        }
    }

    private async Task DeleteAccount(Account? item)
    {
        var command = new DeleteAccount
        {
            Id = item.Id,
            Name = item.Name
        };
        
        var response = await _mediator.Send(command);
        if (response.NumberOfRowsDeleted != 1)
        {
            throw new Exception("Number of rows deleted was not expected after delete account command");
        }
            
        Accounts.Remove(item);
    }
    

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

