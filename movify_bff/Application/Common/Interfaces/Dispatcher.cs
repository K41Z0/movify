using Application.Common.Interfaces;
using Domain.Common.Result;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Interfaces;

/// <summary>
/// Pure implementation of Use Case dispatcher without MediatR.
/// This is the Clean Architecture way - explicit and testable.
/// </summary>
public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result<TResponse>> QueryAsync<TResponse>(
        IQuery<Result<TResponse>> query, 
        CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetRequiredService(handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<Result<TResponse>>?)method?.Invoke(handler, new object[] { query, cancellationToken });

        return await (task ?? Task.FromResult(Result<TResponse>.Failure("Handler not found")));
    }

    public async Task<Result> CommandAsync(
        ICommand command, 
        CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var handler = _serviceProvider.GetRequiredService(handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<Result>?)method?.Invoke(handler, new object[] { command, cancellationToken });

        return await (task ?? Task.FromResult(Result.Failure("Handler not found")));
    }
}