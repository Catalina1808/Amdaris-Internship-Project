using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;
using Moq;

namespace BookLoversProject.Application.XUnitTest
{
    public class GetBooksQueryTest
    {
        [Fact]
        public async Task GetBooksTest()
        {
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

            var books = await mock.Object.Send(new GetBooksQuery());

            Assert.NotNull(books);
            Assert.Equal(2, books.Count());
        }
    }
}