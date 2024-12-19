using CarBook.Application.Authors.Mediator.Handlers.QueryHandlers.AuthorHandlers;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using Moq;
using Xunit;

namespace CarBook.Test.QueryHandlers
{
    public class GetAuthorByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAuthorById()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Author>>();
            var handler = new GetAuthorByIdQueryHandler(mockRepository.Object);

            var mockAuthor = new Author
            {
                Id = 1,
                AuthorName = "Test Author",
                Description = "Test Description",
                ImageUrl = "https://example.com/image.jpg",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            mockRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAuthor);

            var query = new GetAuthorByIdQuery(1);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.AuthorId);
            Assert.Equal("Test Author", result.AuthorName);
            Assert.Equal("Test Description", result.Description);
            Assert.Equal("https://example.com/image.jpg", result.ImageUrl);
            Assert.Equal(mockAuthor.CreatedDate, result.CreatedDate);
            Assert.Equal(mockAuthor.UpdatedDate, result.UpdatedDate);
        }
    }
}
