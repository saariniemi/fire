using FluentValidation.Results;

namespace Niko.Fire.Accounts.Commands;

public class CreateAccountResponse(CreateAccount request) : IResponse<CreateAccount>
{
    public CreateAccount Request => request;

    public Guid Id { get; set; }
}

