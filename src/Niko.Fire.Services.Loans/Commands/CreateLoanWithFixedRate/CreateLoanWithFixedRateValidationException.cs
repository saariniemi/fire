using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanWithFixedRateValidationException : ValidationException
{
    public CreateLoanWithFixedRateValidationException(string message) : base(message)
    {
    }

    public CreateLoanWithFixedRateValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public CreateLoanWithFixedRateValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public CreateLoanWithFixedRateValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public CreateLoanWithFixedRateValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}