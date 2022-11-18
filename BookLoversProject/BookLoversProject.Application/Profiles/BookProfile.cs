using AutoMapper;
using BookLoversProject.Application.Queries.GetBooksQuery;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
