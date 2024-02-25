using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Niko.Fire.Services.Accounts;
using Niko.Fire.Services.Transactions;
using Niko.Fire.Services.Transactions.Commands.CreateTransaction;
using Niko.Fire.Services.Transactions.Requests.GetTransactions;

namespace Niko.Fire.View.ViewModels;

public class TransactionsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    
    public string StatementAmount { get; set; }
    public string StatementDate { get; set; }
    
    public ICommand CreateTransactionCommand { get; }
    public IAsyncRelayCommand<Transaction> DeleteTransactionCommand { get; }
    public IAsyncRelayCommand<Transaction> EditTransactionCommand { get; }
    
    public ObservableCollection<Transaction> Transactions { get; private set; } = [];

    private readonly IMediator _mediator;
    private readonly Account _myAccount;

    public TransactionsViewModel(IMediator mediator)
    {
        _myAccount = new Account { Id = Guid.Parse("030f5a4b-b192-40f7-84d6-e1b8d08aecf4") };
        
        Task.Run(async () =>
        {
            var request = new GetTransactions
            {
                Account = _myAccount
            };

            var transactions = await mediator.Send(request);
            Transactions = new ObservableCollection<Transaction>(transactions);
            OnPropertyChanged(nameof(Transactions));
        });
        
        CreateTransactionCommand = new AsyncRelayCommand(CreateTransaction);
        DeleteTransactionCommand = new AsyncRelayCommand<Transaction>(DeleteTransaction);
        EditTransactionCommand = new AsyncRelayCommand<Transaction>(EditTransaction);

        _mediator = mediator;
    }
    
    private async Task CreateTransaction()
    {
        var newTransactionName = await Application.Current.MainPage.DisplayPromptAsync("Create a transaction", "Enter your transaction", maxLength: 30, keyboard: Keyboard.Plain);

        if (newTransactionName == null)
        {
            return;
        } 
        
        var command = new CreateTransaction
        {
            Account = _myAccount,
            Description = newTransactionName,
            Amount = -1,
            Date = DateTime.Now
        };
        
        var createTransactionResponse = await _mediator.Send(command);

        if (createTransactionResponse.Id != Guid.Empty)
        {
            var transactions = await _mediator.Send(new GetTransactions { Account = _myAccount });
            Transactions.Add(transactions.Single(transaction => transaction.Id == createTransactionResponse.Id));
        }
    }
    
    private async Task DeleteTransaction(Transaction? arg)
    {
        // throw new NotImplementedException();
    }
    
    private async Task EditTransaction(Transaction? arg)
    {
        // throw new NotImplementedException();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}