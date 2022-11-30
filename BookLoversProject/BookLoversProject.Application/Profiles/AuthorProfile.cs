using AutoMapper;
using BookLoversProject.Application.Queries.GetAuthorsQuery;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();
        }
    }
}
