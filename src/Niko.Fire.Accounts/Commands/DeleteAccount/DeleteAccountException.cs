using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Accounts.Commands;

public class DeleteAccountException : ValidationException
{
    public DeleteAccountException(string message) : base(message)
    {
    }

    public DeleteAccountException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public DeleteAccountException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public DeleteAccountException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public DeleteAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}