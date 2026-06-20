using Application.Features.Movies.Queries;
using Application.Interfaces;
using Domain.Dto.Movie;
using Domain.Models;
using Domain.Repositories.MovieRepository.Props;
using Moq;
using Xunit;

namespace Api.Tests.Application.Features.Movies.Queries;

public class SearchMoviesQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _repositoryMock;
    private readonly SearchMoviesQueryHandler _handler;

    public SearchMoviesQueryHandlerTests()
    {
        _repositoryMock = new Mock<IMovieRepository>();
        _handler = new SearchMoviesQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidQuery_ReturnsMovies()
    {
        var query = new SearchMoviesQuery("Inception", 1, null, null);
        
        var movie = new Movie("Inception", "2010", "tt1375666", "movie", "https://example.com/poster.jpg");
        var expectedResult = new ListResult<Movie>
        {
            Search = new List<Movie> { movie },
            TotalResults = 1
        };

        _repositoryMock.Setup(r => r.SearchMoviesAsync(It.IsAny<MovieFilter>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.False(result.HasError);
        Assert.Single(result.Items);
        Assert.Equal("Inception", result.Items.First().Title);
    }
}