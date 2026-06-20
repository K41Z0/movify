using Application.Common.Interfaces;
using Application.Interfaces;
using Domain.Common.Result;
using Domain.Dto.Movie;

namespace Application.UseCases.Movies.GetMovieById;

/// <summary>
/// Clean Architecture Query Handler - Get Movie By ID
/// Fully generic, reusable pattern for future projects.
/// </summary>
public class GetMovieByIdHandler : IQueryHandler<GetMovieByIdQuery, MovieDetails?>
{
    private readonly IMovieRepository _repository;

    public GetMovieByIdHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<MovieDetails?>> HandleAsync(
        GetMovieByIdQuery query, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query.ImdbId))
            return Result<MovieDetails?>.Failure("IMDB ID cannot be empty", ErrorType.Validation);

        if (!ImdbId.IsValid(query.ImdbId))
            return Result<MovieDetails?>.Failure("Invalid IMDB ID format", ErrorType.Validation);

        return await _repository.GetByIdAsync(query.ImdbId, cancellationToken);
    }
}