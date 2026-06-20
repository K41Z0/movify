using Application.Common.Interfaces;
using Domain.Common.Result;
using Domain.Models;

namespace Application.UseCases.Movies.SearchMovies;

/// <summary>
/// Clean Architecture Query - Search Movies Use Case
/// </summary>
public record SearchMoviesQuery(string Title = "", int Page = 1, int? Year = null, string? Type = null)
    : IQuery<Result<ListResult<Movie>>>;