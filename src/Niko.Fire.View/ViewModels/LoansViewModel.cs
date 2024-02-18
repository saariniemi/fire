using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Niko.Fire.Services.Loans;
using Niko.Fire.Services.Loans.Commands;
using Niko.Fire.Services.Loans.Requests;
using Niko.Fire.View.Views;

namespace Niko.Fire.View.ViewModels;

public class LoansViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ICommand CreateLoanCommand { get; }
    
    public ObservableCollection<Loan> Loans { get; private set; } = [];
    
    private readonly IMediator _mediator;
    public LoansViewModel(IMediator mediator)
    {
        Task.Run(async () =>
        {
            var loans = await mediator.Send(new GetLoans());
            Loans = new ObservableCollection<Loan>(loans);
            OnPropertyChanged(nameof(Loans));
        });
        
        CreateLoanCommand = new AsyncRelayCommand(CreateLoan);

        _mediator = mediator;
    }

    private async Task CreateLoan()
    {
        var newLoanName = await Application.Current.MainPage.DisplayPromptAsync("Create a loan", "Enter your loan name", maxLength: 30, keyboard: Keyboard.Plain);
        
        var command = new CreateLoan()
        {
            Name = newLoanName
        };
        
        var createLoanResponse = await _mediator.Send(command);

        if (createLoanResponse.Id != Guid.Empty)
        {
            var loans = await _mediator.Send(new GetLoans());
            Loans.Add(loans.Single(loan => loan.Id == createLoanResponse.Id));
            OnPropertyChanged(nameof(Loans));
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}