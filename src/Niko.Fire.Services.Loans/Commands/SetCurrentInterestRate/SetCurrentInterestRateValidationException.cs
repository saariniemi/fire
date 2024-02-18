using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Loans.Commands;

public class SetCurrentInterestRateValidationException : ValidationException
{
    public SetCurrentInterestRateValidationException(string message) : base(message)
    {
    }

    public SetCurrentInterestRateValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public SetCurrentInterestRateValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public SetCurrentInterestRateValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public SetCurrentInterestRateValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}