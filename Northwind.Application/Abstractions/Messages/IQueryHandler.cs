using MediatR;
using Northwind.Domain.Shared;

namespace Northwind.Application.Abstractions.Messages;

public interface IQueryHandler<in TQuery,TResponse>: IRequestHandler<TQuery,Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}