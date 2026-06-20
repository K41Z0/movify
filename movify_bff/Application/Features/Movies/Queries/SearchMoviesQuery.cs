using Application.Interfaces;
using Domain.Dto.Movie;
using Domain.Models;
using Domain.Repositories.MovieRepository.Props;

namespace Application.Features.Movies.Queries;

public record SearchMoviesQuery(
    string Title,
    int Page = 1,
    int? Year = null,
    string? Type = null);

public class SearchMoviesQueryHandler
{
    private readonly IMovieRepository _repository;

    public SearchMoviesQueryHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListResult<Movie>> Handle(SearchMoviesQuery query, CancellationToken cancellationToken = default)
    {
        var filter = new MovieFilter
        {
            Title = query.Title,
            Page = query.Page,
            Year = query.Year,
            Type = query.Type
        };

        var result = await _repository.SearchMoviesAsync(filter, cancellationToken);

        if (result.HasError)
            throw new Application.Common.Exceptions.NotFoundException(result.ErrorMessage ?? "Movie not found");

        return result;
    }
}
