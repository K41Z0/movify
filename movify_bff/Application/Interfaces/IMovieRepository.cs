using Domain.Dto.Movie;
using Domain.Models;
using Domain.Repositories.MovieRepository.Props;

namespace Application.Interfaces;

public interface IMovieRepository
{
    Task<ListResult<Movie>> SearchMoviesAsync(MovieFilter filter, CancellationToken cancellationToken = default);
    Task<MovieDetails?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}
