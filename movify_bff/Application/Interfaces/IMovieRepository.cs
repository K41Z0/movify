using Domain.Common.Result;
using Domain.Models;

namespace Application.Interfaces;

/// <summary>
/// Application layer abstraction for movie data access.
/// Declared in Application according to Clean Architecture (Interface Ownership).
/// </summary>
public interface IMovieRepository
{
    Task<Result<ListResult<Movie>>> SearchMoviesAsync(MovieFilter filter, CancellationToken cancellationToken = default);
    Task<Result<MovieDetails?>> GetByIdAsync(string imdbId, CancellationToken cancellationToken = default);
}