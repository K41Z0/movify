using Domain.Common.Result;

namespace Application.Common.Interfaces;

/// <summary>
/// Central dispatcher for all Use Cases (Queries and Commands).
/// This is the only place where Application layer is accessed from outside.
/// Follows Clean Architecture - Api depends only on this abstraction.
/// </summary>
public interface IDispatcher
{
    Task<Result<TResponse>> QueryAsync<TResponse>(IQuery<Result<TResponse>> query, CancellationToken cancellationToken = default);
    Task<Result> CommandAsync(ICommand command, CancellationToken cancellationToken = default);
}