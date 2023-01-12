using AutoMapper;
using BookLoversProject.Api.Controllers;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Delete.DeleteShelfCommand;
using BookLoversProject.Application.Commands.Update.UpdateShelfCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Application.Queries.GetShelfByIdQuery;
using BookLoversProject.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookLoversProject.Presentation.UnitTest
{
    [TestClass]
    public class ShelfControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetShelfByIdQueryShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetShelfByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetShelfByIdQuery, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ShelfGetDTO
                        {
                            Id = q.Id,
                            Name = "Shelf",
                            Books = new List<BookGetDTO>
                            {
                                new BookGetDTO
                                {
                                    Id = 1,
                                    Title= "Title"
                                }
                            }
                        });
                });

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetShelfByIdQueryShouldReturnFoundShelf()
        {
            var shelf = new ShelfGetDTO
            {
                Id = 1,
                Name = "Shelf",
                Books = new List<BookGetDTO>
                  {
                     new BookGetDTO
                     {
                         Id = 1,
                         Title= "Title"
                     }
                }
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetShelfByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(shelf);

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(shelf, okResult.Value);
        }

        [TestMethod]
        public async Task UpdateShelfQueryShouldReturnOKStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<UpdateShelfCommand>(It.IsAny<ShelfPutDTO>()))
                .Returns((ShelfPutDTO a) => new UpdateShelfCommand()
                {
                    Name = a.Name
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateShelfCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateShelfCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ShelfGetDTO
                        {
                            Id = 1,
                            Name = "Shelf",
                            Books = new List<BookGetDTO>
                            {
                                new BookGetDTO
                                {
                                    Id = 1,
                                    Title = "Title",
                                    Description = "Book description",
                                }
                            }
                        });
                });

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.UpdateShelf(1, new ShelfPutDTO
            {
                Name = "Shelf",
            });

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteShelfQueryShouldReturnNoContentStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteShelfCommand>(), It.IsAny<CancellationToken>()))
                .Returns<DeleteShelfCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new Shelf
                        {
                            Id = 1,
                            Name = "Shelf",
                            Books = new List<ShelfBook>
                            {
                                new ShelfBook
                                {
                                    BookId = 1,
                                    ShelfId = 1
                                }
                            }
                        });
                });

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.DeleteShelf(1);

            var okResult = result as NoContentResult;

            Assert.AreEqual((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateShelfQueryShouldReturnCreatedStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<CreateShelfCommand>(It.IsAny<ShelfPostDTO>()))
                .Returns((ShelfPostDTO a) => new CreateShelfCommand()
                {
                    Name = a.Name,
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateShelfCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateShelfCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ShelfGetDTO
                        {
                            Id = 1,
                            Name = "Shelf"
                        });
                });

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.CreateShelf(new ShelfPostDTO
            {
                Name = "Shelf",
            });

            var created = result as CreatedAtActionResult;

            Assert.AreEqual((int)HttpStatusCode.Created, created.StatusCode);
        }

        [TestMethod]
        public async Task CreateShelfQueryShouldReturnGenre()
        {
            _mockMapper
                .Setup(m => m.Map<CreateShelfCommand>(It.IsAny<ShelfPostDTO>()))
                .Returns((ShelfPostDTO a) => new CreateShelfCommand()
                {
                    Name = a.Name,
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateShelfCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateShelfCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ShelfGetDTO
                        {
                            Id = 1,
                            Name = "Shelf"
                        });
                });

            var controller = new ShelvesController(_mockMediator.Object, _mockMapper.Object);

            ShelfPostDTO shelfPutPost = new ShelfPostDTO
            {
                Name = "Shelf",
            };

            var result = await controller.CreateShelf(shelfPutPost);

            var created = result as CreatedAtActionResult;

            Assert.AreEqual(shelfPutPost.Name, ((ShelfGetDTO)created.Value).Name);
        }
    }
}
