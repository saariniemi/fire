using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Loans.Commands;

public class CreateLoanValidationException : ValidationException
{
    public CreateLoanValidationException(string message) : base(message)
    {
    }

    public CreateLoanValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public CreateLoanValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public CreateLoanValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public CreateLoanValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}