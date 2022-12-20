using AutoMapper;
using BookLoversProject.Api.Controllers;
using BookLoversProject.Application.Commands.Create.CreateAuthorCommand;
using BookLoversProject.Application.Commands.Delete.DeleteAuthorCommand;
using BookLoversProject.Application.Commands.Update.UpdateAuthorCommand;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Queries.GetAuthorByIdQuery;
using BookLoversProject.Application.Queries.GetAuthorsQuery;
using BookLoversProject.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookLoversProject.Presentation.UnitTest
{
    [TestClass]
    public class AuthorControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllAuthorsQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAuthorsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAll();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAuthorsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }


        [TestMethod]
        public async Task GetAuthorByIdQueryIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetAuthorByIdQueryWithCorrectAuthorIsCalled()
        {
            int authorId = 0;

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetAuthorByIdQuery, CancellationToken>(async (q, c) =>
                {
                    authorId = q.Id;
                    return await Task.FromResult(
                        new AuthorGetDTO
                        {
                            Id = q.Id,
                            Name = "Author Name",
                            Description= "Description",
                            Books= new List<BookDTO>
                            {
                                new BookDTO
                                {
                                    Id = 1,
                                    Title= "Title"
                                }
                            }
                        });
                });

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetById(1);

            Assert.AreEqual(authorId, 1);
        }

        [TestMethod]
        public async Task GetAuthorByIdQueryShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetAuthorByIdQuery, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new AuthorGetDTO
                        {
                            Id = q.Id,
                            Name = "Author Name",
                            Description = "Description",
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

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int) HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetAuthorByIdQueryShouldReturnFoundAuthor()
        {
            var author = new AuthorGetDTO
            {
                Id = 1,
                Name = "Author Name",
                Description = "Description",
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
                .Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(author);

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(author, okResult.Value);
        }

        [TestMethod]
        public async Task UpdateAuthorQueryShouldReturnOkStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<UpdateAuthorCommand>(It.IsAny<AuthorPutPostDTO>()))
                .Returns((AuthorPutPostDTO a) => new UpdateAuthorCommand()
                {
                    Name = a.Name,
                    Description = a.Description
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateAuthorCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateAuthorCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new AuthorGetDTO
                        {
                            Id = 1,
                            Name = "Author Name",
                            Description = "Author description",
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

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.UpdateAuthor(1, new AuthorPutPostDTO
            {
                Name = "Author Name",
                Description = "Author description",
            });

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteAuthorQueryShouldReturnNoContentStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteAuthorCommand>(), It.IsAny<CancellationToken>()))
                .Returns<DeleteAuthorCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new Author
                        {
                            Id = 1,
                            Name = "Author Name",
                            Description = "Description",
                            Books = new List<BookAuthor>
                            {
                                new BookAuthor
                                {
                                    BookId = 1,
                                    AuthorId = 1
                                }
                            }
                        });
                });

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.DeleteAuthor(1);

            var okResult = result as NoContentResult;

            Assert.AreEqual((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateAuthorQueryShouldReturnCreatedStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<CreateAuthorCommand>(It.IsAny<AuthorPutPostDTO>()))
                .Returns((AuthorPutPostDTO a) => new CreateAuthorCommand()
                {
                    Name = a.Name,
                    Description = a.Description
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateAuthorCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateAuthorCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new AuthorGetDTO
                        {
                            Id = 1,
                            Name = "Author Name",
                            Description = "Author description",
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

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.CreateAuthor(new AuthorPutPostDTO
            {
                Name = "Author Name",
                Description = "Description",
            });

            var created = result as CreatedAtActionResult;

            Assert.AreEqual((int)HttpStatusCode.Created, created.StatusCode);
        }

        [TestMethod]
        public async Task CreateAuthorQueryShouldReturnAuthor()
        {
            _mockMapper
                .Setup(m => m.Map<CreateAuthorCommand>(It.IsAny<AuthorPutPostDTO>()))
                .Returns((AuthorPutPostDTO a) => new CreateAuthorCommand()
                {
                    Name = a.Name,
                    Description = a.Description
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateAuthorCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateAuthorCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new AuthorGetDTO
                        {
                            Id = 1,
                            Name = "Author Name",
                            Description = "Author description",
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

            var controller = new AuthorsController(_mockMediator.Object, _mockMapper.Object);

            AuthorPutPostDTO authorPutPost = new AuthorPutPostDTO
            {
                Name = "Author Name",
                Description = "Description",
            };

            var result = await controller.CreateAuthor(authorPutPost);

            var created = result as CreatedAtActionResult;

            Assert.AreEqual(authorPutPost.Name, ((AuthorGetDTO)created.Value).Name);
        }
    }
}