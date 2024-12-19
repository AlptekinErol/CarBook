using CarBook.Application.Features.Mediator.Handlers.QueryHandlers.AuthorHandlers;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using Moq;
using Xunit;

namespace CarBook.Test.QueryHandlers
{
    public class GetAuthorQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnListOfGetAuthorQueryResults()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Author>>();
            var handler = new GetAuthorQueryHandler(mockRepository.Object);

            var mockData = new List<Author>
            {
                new Author { Id = 1, AuthorName = "Author 1", Description = "Description 1", ImageUrl = "https://example.com/image1.jpg" },
                new Author { Id = 2, AuthorName = "Author 2", Description = "Description 2", ImageUrl = "https://example.com/image2.jpg" },
            };

            mockRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(mockData);

            var query = new GetAuthorQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Author 1", result[0].AuthorName);
            Assert.Equal("Description 1", result[0].Description);
            Assert.Equal("https://example.com/image1.jpg", result[0].ImageUrl);
        }
    }
}
