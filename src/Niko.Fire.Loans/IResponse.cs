using FluentValidation.Results;
using MediatR;

namespace Niko.Fire.Loans; // TODO: CAN I SHARE THIS FOR ALL SERVICES? MAYBE HAVE AN SERVICE NAMESPACE




/// <summary>
/// Marker interface to represent a request with a response
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface IResponse<TRequest>
    where TRequest : IRequest<object>
{
    TRequest Request { get; }
}

