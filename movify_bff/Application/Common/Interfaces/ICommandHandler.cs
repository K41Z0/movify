using Domain.Common.Result;

namespace Application.Common.Interfaces;

/// <summary>
/// Handler for commands following Clean Architecture CQRS pattern.
/// Pure implementation without MediatR.
/// </summary>
public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}