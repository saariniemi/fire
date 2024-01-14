namespace Niko.Fire.Accounts.Responses;

public interface IResponse { }

public class CreateAccountResponse : IResponse
{
    public Guid Id { get; set; }
}