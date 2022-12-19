using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.Commands.Update.UpdateUserCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserPutPostDTO, UpdateUserCommand>();
            CreateMap<UserPutPostDTO, CreateUserCommand>(); 
            CreateMap<User, UserGetDTO>()
                .ForMember(userDTO => userDTO.Authors, opt => opt.MapFrom(user => user.Authors.Select(userAuthor => userAuthor.Author)));
            CreateMap<User, UserDTO>();
        }
    }
}
