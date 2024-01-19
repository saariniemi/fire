using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Infrastructure.Validators;

public class AccountValidationException : ValidationException
{
    public AccountValidationException(string message) : base(message)
    {
    }

    public AccountValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public AccountValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public AccountValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public AccountValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}