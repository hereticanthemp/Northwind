using MediatR;
using Northwind.Domain.Shared;

namespace Northwind.Application.Abstractions.Messages;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}