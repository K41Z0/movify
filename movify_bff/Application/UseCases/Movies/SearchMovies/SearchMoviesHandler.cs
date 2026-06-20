using Application.Common.Interfaces;
using Domain.Common.Result;
using Domain.Models;
using Application.Interfaces;

namespace Application.UseCases.Movies.SearchMovies;

/// <summary>
/// Clean Architecture Query Handler for SearchMovies use case.
/// Follows Uncle Bob's dependency rule - depends only on abstractions.
/// </summary>
public class SearchMoviesHandler : IQueryHandler<SearchMoviesQuery, ListResult<Movie>>
{
    private readonly IMovieRepository _movieRepository;

    public SearchMoviesHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<ListResult<Movie>>> HandleAsync(
        SearchMoviesQuery query, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query.Title))
            return Result<ListResult<Movie>>.Failure("Search title cannot be empty", ErrorType.Validation);

        var filter = new MovieFilter 
        { 
            Title = query.Title.Trim(), 
            Page = query.Page,
            Year = query.Year,
            Type = query.Type
        };

        var result = await _movieRepository.SearchMoviesAsync(filter, cancellationToken);
        
        return Result<ListResult<Movie>>.Success(result);
    }
}