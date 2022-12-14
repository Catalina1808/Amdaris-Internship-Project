using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateBookCommand;
using BookLoversProject.Application.Commands.Update.UpdateBookCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookPostDTO, CreateBookCommand>();
            CreateMap<BookPutDTO, UpdateBookCommand>();
            CreateMap<Book, BookGetDTO>()
                .ForMember(bookDTO => bookDTO.Authors, opt => opt.MapFrom(book => book.Authors.Select(bookAuthor => bookAuthor.Author)))
                .ForMember(bookDTO => bookDTO.Genres, opt => opt.MapFrom(book => book.Genres.Select(bookGenre => bookGenre.Genre)))
                .ForMember(bookDTO => bookDTO.Shelves, opt => opt.MapFrom(book => book.Shelves.Select(shelfBook => shelfBook.Shelf)));
            CreateMap< Book, BookDTO>();

        }
    }
}
