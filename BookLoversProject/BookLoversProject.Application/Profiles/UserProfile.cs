using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserPutPostDTO, CreateUserCommand>(); // ?
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
