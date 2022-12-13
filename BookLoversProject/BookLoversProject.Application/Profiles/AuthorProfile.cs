using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateAuthorCommand;
using BookLoversProject.Application.Commands.Update.UpdateAuthorCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorPutPostDTO, CreateAuthorCommand>(); // ?
            CreateMap<AuthorPutPostDTO, UpdateAuthorCommand>(); // ?
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
        }
    }
}
