using Application.Interfaces;
using Domain.Dto.Movie;

namespace Application.Features.Movies.Queries;

public record GetMovieByIdQuery(string Id);

public class GetMovieByIdQueryHandler
{
    private readonly IMovieRepository _repository;

    public GetMovieByIdQueryHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<MovieDetails?> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(query.Id, cancellationToken);
    }
}
