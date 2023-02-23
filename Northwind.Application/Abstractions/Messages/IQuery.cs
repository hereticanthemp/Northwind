using MediatR;
using Northwind.Domain.Shared;

namespace Northwind.Application.Abstractions.Messages;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}