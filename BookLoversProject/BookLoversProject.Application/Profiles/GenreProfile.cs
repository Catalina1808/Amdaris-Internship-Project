using AutoMapper;
using BookLoversProject.Application.Queries.GetGenresQuery;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
        }
    }
}
