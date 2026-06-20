using Domain.Common.Result;

namespace Application.Common.Interfaces;

/// <summary>
/// Handler for queries following Clean Architecture CQRS pattern.
/// No MediatR. Pure dependency injection.
/// </summary>
public interface IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<Result<TResponse>>
{
    Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}