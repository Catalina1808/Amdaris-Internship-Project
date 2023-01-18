using AutoMapper;
using BookLoversProject.Api.Controllers;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.Commands.Delete.DeleteUserCommand;
using BookLoversProject.Application.Commands.Update.UpdateUserCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Queries.GetUserByIdQuery;
using BookLoversProject.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BookLoversProject.Presentation.UnitTest
{
    [TestClass]
    public class UserControllerTests
    {
    //    private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
    //    private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

    //    [TestMethod]
    //    public async Task GetUserByIdQueryShouldReturnOkStatusCode()
    //    {
    //        _mockMediator
    //            .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
    //            .Returns<GetUserByIdQuery, CancellationToken>(async (q, c) =>
    //            {
    //                return await Task.FromResult(
    //                    new UserGetDTO
    //                    {
    //                        Id = q.Id,
    //                        FirstName = "First name",
    //                        LastName = "Last name",
    //                        Email = "Email",
    //                        Password = "Password"
    //                    });
    //            });

    //        var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

    //        var result = await controller.GetById(1);

    //        var okResult = result as OkObjectResult;

    //        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
    //    }

    //    [TestMethod]
    //    public async Task GetUserByIdQueryShouldReturnFoundUser()
    //    {
    //        var user = new UserGetDTO
    //        {
    //            Id = 1,
    //            FirstName = "First name",
    //            LastName = "Last name",
    //            Email = "Email",
    //            Password = "Password"
    //        };

    //        _mockMediator
    //            .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
    //            .ReturnsAsync(user);

    //        var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

    //        var result = await controller.GetById(1);

    //        var okResult = result as OkObjectResult;

    //        Assert.AreEqual(user, okResult.Value);
    //    }

    //    [TestMethod]
    //    public async Task UpdateUserQueryShouldReturnOKStatusCode()
    //    {
    //        _mockMapper
    //            .Setup(m => m.Map<UpdateUserCommand>(It.IsAny<UserPutPostDTO>()))
    //            .Returns((UserPutPostDTO a) => new UpdateUserCommand()
    //            {
    //                FirstName = a.FirstName,
    //                LastName = a.LastName,
    //                Email = a.Email,
    //                Password = a.Password
    //            });

    //        _mockMediator
    //            .Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
    //            .Returns<UpdateUserCommand, CancellationToken>(async (q, c) =>
    //            {
    //                return await Task.FromResult(
    //                   new UserGetDTO
    //                   {
    //                       Id = q.Id,
    //                       FirstName = "First name",
    //                       LastName = "Last name",
    //                       Email = "Email",
    //                       Password = "Password"
    //                   });
    //            });

    //        var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

    //        var result = await controller.UpdateUser(1, new UserPutPostDTO
    //        {
    //            FirstName = "First name",
    //            LastName = "Last name",
    //            Email = "Email",
    //            Password = "Password"
    //        });

    //        var okResult = result as OkObjectResult;

    //        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
    //    }

    //    [TestMethod]
    //    public async Task DeleteUserQueryShouldReturnNoContentStatusCode()
    //    {
    //        _mockMediator
    //            .Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), It.IsAny<CancellationToken>()))
    //            .Returns<DeleteUserCommand, CancellationToken>(async (q, c) =>
    //            {
    //                return await Task.FromResult(
    //                      new User
    //                      {
    //                          Id = q.Id.ToString(),
    //                          FirstName = "First name",
    //                          LastName = "Last name",
    //                          Email = "Email",
    //                          Password = "Password"
    //                      });
    //            });

    //        var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

    //        var result = await controller.DeleteUser(1);

    //        var okResult = result as NoContentResult;

    //        Assert.AreEqual((int)HttpStatusCode.NoContent, okResult.StatusCode);
    //    }

    //    [TestMethod]
    //    public async Task CreateUserQueryShouldReturnUser()
    //    {
    //        _mockMapper
    //            .Setup(m => m.Map<CreateUserCommand>(It.IsAny<UserPutPostDTO>()))
    //            .Returns((UserPutPostDTO a) => new CreateUserCommand()
    //            {
    //                FirstName = a.FirstName,
    //                LastName = a.LastName,
    //                Email = a.Email,
    //                Password = a.Password
    //            });

    //        _mockMediator
    //            .Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
    //            .Returns<CreateUserCommand, CancellationToken>(async (q, c) =>
    //            {
    //                return await Task.FromResult(
    //                   new UserGetDTO
    //                   {
    //                       Id = 1,
    //                       FirstName = "First name",
    //                       LastName = "Last name",
    //                       Email = "Email",
    //                       Password = "Password"
    //                   });
    //            });

    //        var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);

    //        UserPutPostDTO userPutPost = new UserPutPostDTO
    //        {
    //            FirstName = "First name",
    //            LastName = "Last name",
    //            Email = "Email",
    //            Password = "Password"
    //        };

    //        var result = await controller.CreateUser(userPutPost);

    //        var created = result as CreatedAtActionResult;

    //        Assert.AreEqual(userPutPost.FirstName, ((UserGetDTO)created.Value).FirstName);
    //    }
    }
}