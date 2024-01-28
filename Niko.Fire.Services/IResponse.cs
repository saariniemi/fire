using MediatR;

namespace Niko.Fire.Services;

/// <summary>
/// Marker interface to represent a request with a response
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface IResponse<TRequest>
    where TRequest : IRequest<object>
{
    TRequest Request { get; }
}
