using FluentValidation.Results;
using MediatR;

namespace Niko.Fire.Accounts;




/// <summary>
/// Marker interface to represent a request with a response
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface IResponse<TRequest>
    where TRequest : IRequest<object>
{
    TRequest Request { get; }
    
    ValidationResult? ValidationResult { get;  }
}

