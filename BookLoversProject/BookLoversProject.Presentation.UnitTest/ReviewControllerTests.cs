using AutoMapper;
using BookLoversProject.Api.Controllers;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Create.CreateReviewCommand;
using BookLoversProject.Application.Commands.Delete.DeleteGenreCommand;
using BookLoversProject.Application.Commands.Delete.DeleteReviewCommand;
using BookLoversProject.Application.Commands.Update.UpdateGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateReviewCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Application.Queries.GetGenreByIdQuery;
using BookLoversProject.Application.Queries.GetReviewByIdQuery;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookLoversProject.Presentation.UnitTest
{
    [TestClass]
    public class ReviewControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetReviewByIdQueryShouldReturnOkStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetReviewByIdQuery, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ReviewGetDTO
                        {
                            Id = q.Id,
                            Comment = "Great book!",
                            BookId = 1,
                            UserId = 1,
                            Date = DateTime.Now
                        });
                });

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetReviewByIdQueryShouldReturnFoundReview()
        {
            var review = new ReviewGetDTO
            {
                Comment = "Great book!",
                BookId = 1,
                UserId = 1,
                Date = DateTime.Now
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(review);

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(review, okResult.Value);
        }

        [TestMethod]
        public async Task UpdateReviewQueryShouldReturnOKStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<UpdateReviewCommand>(It.IsAny<ReviewPutDTO>()))
                .Returns((ReviewPutDTO a) => new UpdateReviewCommand()
                {
                    Comment = a.Comment
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateReviewCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ReviewGetDTO
                        {
                            Id = q.Id,
                            Comment = "Great book!",
                            BookId = 1,
                            UserId = 1,
                            Date = DateTime.Now
                        });
                });

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.UpdateReview(1, new ReviewPutDTO
            {
                Comment = "Great book!",
            });

            var okResult = result as OkObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task DeleteReviewQueryShouldReturnNoContentStatusCode()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns<DeleteReviewCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new Review
                        {
                            Id = q.Id,
                            Comment = "Great book!",
                            BookId = 1,
                            UserId = 1,
                            Date = DateTime.Now
                        });
                });

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.DeleteReview(1);

            var okResult = result as NoContentResult;

            Assert.AreEqual((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateReviewQueryShouldReturnCreatedStatusCode()
        {
            _mockMapper
                .Setup(m => m.Map<CreateReviewCommand>(It.IsAny<ReviewPostDTO>()))
                .Returns((ReviewPostDTO a) => new CreateReviewCommand()
                {
                    Comment = a.Comment,
                    UserId = a.UserId,
                    BookId = a.BookId
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateReviewCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ReviewGetDTO
                        {
                            Comment = "Great book!",
                            BookId = 1,
                            UserId = 1,
                            Date = DateTime.Now
                        });
                });

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.CreateReview(new ReviewPostDTO
            {
                Comment = "Great book!",
                UserId = 1,
                BookId = 1
            });

            var created = result as CreatedAtActionResult;

            Assert.AreEqual((int)HttpStatusCode.Created, created.StatusCode);
        }

        [TestMethod]
        public async Task CreateReviewQueryShouldReturnGenre()
        {
            _mockMapper
                .Setup(m => m.Map<CreateReviewCommand>(It.IsAny<ReviewPostDTO>()))
                .Returns((ReviewPostDTO a) => new CreateReviewCommand()
                {
                    Comment = a.Comment,
                    UserId = a.UserId,
                    BookId = a.BookId
                });

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns<CreateReviewCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                        new ReviewGetDTO
                        {
                            Comment = "Great book!",
                            BookId = 1,
                            UserId = 1,
                            Date = DateTime.Now
                        });
                });

            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object);

            ReviewPostDTO reviewPutPost = new ReviewPostDTO
            {
                Comment = "Great book!",
                UserId = 1,
                BookId = 1
            };

            var result = await controller.CreateReview(reviewPutPost);

            var created = result as CreatedAtActionResult;

            Assert.AreEqual(reviewPutPost.Comment, ((ReviewGetDTO)created.Value).Comment);
        }
    }
}
