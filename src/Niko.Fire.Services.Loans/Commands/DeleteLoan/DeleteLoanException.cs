using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Niko.Fire.Services.Loans.Commands;

public class DeleteLoanException : ValidationException
{
    public DeleteLoanException(string message) : base(message)
    {
    }

    public DeleteLoanException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public DeleteLoanException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public DeleteLoanException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public DeleteLoanException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}