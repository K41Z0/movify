using Application.Common.Interfaces;
using Application.Interfaces;
using Application.UseCases.Movies.GetMovieById;
using Application.UseCases.Movies.SearchMovies;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions;

/// <summary>
/// Extension methods for clean and scalable dependency injection.
/// This is the recommended pattern for real Clean Architecture projects.
/// Highly reusable for other projects.
/// </summary>
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();

        // Query Handlers
        services.AddScoped<IQueryHandler<SearchMoviesQuery, ListResult<Movie>>, SearchMoviesHandler>();
        services.AddScoped<IQueryHandler<GetMovieByIdQuery, MovieDetails?>, GetMovieByIdHandler>();

        // Command Handlers will be registered here in the future

        return services;
    }
}