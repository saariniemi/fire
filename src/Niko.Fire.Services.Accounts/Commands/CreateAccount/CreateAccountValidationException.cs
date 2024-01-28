using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Accounts.Commands;

public class CreateAccountValidationException : ValidationException
{
    public CreateAccountValidationException(string message) : base(message)
    {
    }

    public CreateAccountValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public CreateAccountValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public CreateAccountValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public CreateAccountValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}