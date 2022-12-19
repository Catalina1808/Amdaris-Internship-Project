using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateAuthorCommand;
using BookLoversProject.Application.Commands.Update.UpdateAuthorCommand;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorPutPostDTO, CreateAuthorCommand>();
            CreateMap<AuthorPutPostDTO, UpdateAuthorCommand>();
            CreateMap<Author, AuthorGetDTO>()
                .ForMember(authorDTO => authorDTO.Books, opt => opt.MapFrom(author => author.Books.Select(bookAuthor => bookAuthor.Book)))
                .ForMember(authorDTO => authorDTO.Followers, opt => opt.MapFrom(author => author.Followers.Select(userAuthor => userAuthor.User)));
            CreateMap<Author, AuthorDTO>();

        }
    }
}
