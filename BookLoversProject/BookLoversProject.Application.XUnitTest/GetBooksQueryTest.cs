using BookLoversProject.Application.Queries.GetBookByIdQuery;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;
using Moq;

namespace BookLoversProject.Application.XUnitTest
{
    public class GetBooksQueryTests
    {
        [Fact]
        public async Task GetBooksQuery_ShouldReturnBook()
        {
            // Arrange
            Mock<IMediator> mock = new Mock<IMediator>();
            mock.Setup(x => x.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()))
            .Returns(() => Task.FromResult(new List<BookDTO>
            {
                new BookDTO
                {
                    Id = 1,
                    Title = "title1",
                    Description = "description1"
                },
                new BookDTO
                {
                    Id = 2,
                    Title = "title2",
                    Description = "description2"
                }
            }
            .AsEnumerable()));

            // Act
            var books = await mock.Object.Send(new GetBooksQuery());

            // Assert
            Assert.NotNull(books);
            Assert.Equal(2, books.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetBookByIdQuery_ShouldReturnBooks(int id)
        {

            // Arrange
            Mock<IMediator> mock = new Mock<IMediator>();
            mock.Setup(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()))
            .Returns(() => Task.FromResult(new BookDTO
            {
                Id = 1,
                Title = "title1",
                Description = "description1"
            }));

            // Act
            var book = await mock.Object.Send(new GetBookByIdQuery { Id = id });

            // Assert
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
        }

        [Fact]
        public async Task GetBooksQuery_ShouldReturnZeroBooks()
        {

        }
    }
}