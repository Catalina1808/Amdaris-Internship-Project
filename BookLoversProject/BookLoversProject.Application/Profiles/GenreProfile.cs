using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateGenreCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenrePutPostDTO, UpdateGenreCommand>();
            CreateMap<GenrePutPostDTO, CreateGenreCommand>();
            CreateMap<Genre, GenreGetDTO>()
                .ForMember(genreDTO => genreDTO.Books, opt => opt.MapFrom(genre => genre.Books.Select(genreBook => genreBook.Book)));
            CreateMap<Genre, GenreDTO>();
        }
    }
}
