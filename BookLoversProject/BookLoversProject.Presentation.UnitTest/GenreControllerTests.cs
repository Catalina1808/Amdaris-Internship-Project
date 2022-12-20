using AutoMapper;
using BookLoversProject.Api.Controllers;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Delete.DeleteGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateGenreCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.Queries.GetGenreByIdQuery;
using BookLoversProject.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookLoversProject.Presentation.UnitTest
{
    [TestClass]
    public class GenreControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetGenreByIdQueryShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetGenreByIdQuery, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new GenreGetDTO
                        {
                            Id = q.Id,
                            Name = "Contemporary",
                            Books = new List<BookDTO>
                            {
                                new BookDTO
                                {
                                    Id = 1,
                                    Title= "Title"
                                }
                            }
                        });
                });

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetGenreByIdQueryShouldReturnFoundGenre()
        {
            var genre = new GenreGetDTO
            {
                Id = 1,
                Name = "Contemporary",
                Books = new List<BookDTO>
                  {
                     new BookDTO
                     {
                         Id = 1,
                         Title= "Title"
                     }
                }
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(genre);

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(genre, okResult.Value);
        }

        [TestMethod]
        public async Task UpdateGenreQueryShouldReturnOKStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<UpdateGenreCommand>(It.IsAny<GenrePutPostDTO>()))
                .Returns((GenrePutPostDTO a) => new UpdateGenreCommand()
                {
                    Name = a.Name
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateGenreCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateGenreCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new GenreGetDTO
                        {
                            Id = 1,
                            Name = "Contemporary",
                            Books = new List<BookDTO>
                            {
                                new BookDTO
                                {
                                    Id = 1,
                                    Title = "Title",
                                    Description = "Book description",
                                }
                            }
                        });
                });

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.UpdateGenre(1, new GenrePutPostDTO
            {
                Name = "Genre Name",
            });

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteGenreQueryShouldReturnNoContentStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteGenreCommand>(), It.IsAny<CancellationToken>()))
                .Returns<DeleteGenreCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new Genre
                        {
                            Id = 1,
                            Name = "Genre Name",
                            Books = new List<GenreBook>
                            {
                                new GenreBook
                                {
                                    BookId = 1,
                                    GenreId = 1
                                }
                            }
                        });
                });

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.DeleteGenre(1);

            var okResult = result as NoContentResult;

            Assert.AreEqual((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateGenreQueryShouldReturnCreatedStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<CreateGenreCommand>(It.IsAny<GenrePutPostDTO>()))
                .Returns((GenrePutPostDTO a) => new CreateGenreCommand()
                {
                    Name = a.Name,
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateGenreCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateGenreCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new GenreGetDTO
                        {
                            Id = 1,
                            Name = "Contemporary",
                            Books = new List<BookDTO>
                            {
                                new BookDTO
                                {
                                    Id = 1,
                                    Title = "Title",
                                    Description = "Book description",
                                }
                            }
                        });
                });

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.CreateGenre(new GenrePutPostDTO
            {
                Name = "Author Name",
            });

            var created = result as CreatedAtActionResult;

            Assert.AreEqual((int)HttpStatusCode.Created, created.StatusCode);
        }

        [TestMethod]
        public async Task CreateGenreQueryShouldReturnGenre()
        {
            _mockMapper
                .Setup(m => m.Map<CreateGenreCommand>(It.IsAny<GenrePutPostDTO>()))
                .Returns((GenrePutPostDTO a) => new CreateGenreCommand()
                {
                    Name = a.Name,
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateGenreCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateGenreCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new GenreGetDTO
                        {
                            Id = 1,
                            Name = "Contemporary",
                            Books = new List<BookDTO>
                            {
                                new BookDTO
                                {
                                    Id = 1,
                                    Title = "Title",
                                    Description = "Book description",
                                }
                            }
                        });
                });

            var controller = new GenresController(_mockMediator.Object, _mockMapper.Object);

            GenrePutPostDTO genrePutPost = new GenrePutPostDTO
            {
                Name = "Contemporary",
            };

            var result = await controller.CreateGenre(genrePutPost);

            var created = result as CreatedAtActionResult;

            Assert.AreEqual(genrePutPost.Name, ((GenreGetDTO)created.Value).Name);
        }
    }
}
