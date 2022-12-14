using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenrePutPostDTO, CreateGenreCommand>();
            CreateMap<Genre, GenreGetDTO>()
                .ForMember(genreDTO => genreDTO.Books, opt => opt.MapFrom(genre => genre.Books.Select(genreBook => genreBook.Book)));
            CreateMap<Genre, GenreDTO>();
        }
    }
}
