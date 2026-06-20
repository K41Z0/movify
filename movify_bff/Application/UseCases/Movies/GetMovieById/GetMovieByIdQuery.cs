using Application.Common.Interfaces;
using Domain.Common.Result;
using Domain.Dto.Movie;

namespace Application.UseCases.Movies.GetMovieById;

/// <summary>
/// Clean Architecture Query for retrieving movie by IMDB ID
/// </summary>
public record GetMovieByIdQuery(string ImdbId) : IQuery<Result<MovieDetails?>>;