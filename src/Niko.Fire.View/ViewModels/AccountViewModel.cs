using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Niko.Fire.Services.Accounts.Commands;

namespace Niko.Fire.View.ViewModels;

public class AccountViewModel
{
    private readonly IMediator _mediator;
    public ICommand SaveCommand { get; private set; }

    public AccountViewModel(IMediator mediator)
    {
        _mediator = mediator ?? throw new NotImplementedException();
        SaveCommand = new AsyncRelayCommand(Save); 
    }

    private async Task Save()
    {
        await _mediator.Send(new CreateAccount { Name = "Test 2" });
    }
}