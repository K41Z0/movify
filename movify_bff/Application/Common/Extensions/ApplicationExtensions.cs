using Application.Common.Interfaces;
using Application.UseCases.Movies.SearchMovies;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions;

/// <summary>
/// Clean DI registration following Clean Architecture principles.
/// All Use Case handlers are registered here.
/// </summary>
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register Dispatcher
        services.AddScoped<IDispatcher, Dispatcher>();

        // Register Query Handlers
        services.AddScoped<IQueryHandler<SearchMoviesQuery, ListResult<Movie>>, SearchMoviesHandler>();

        // Register Command Handlers here in the future

        return services;
    }
}