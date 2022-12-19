using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Update.UpdateShelfCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ShelfProfile: Profile
    {
        public ShelfProfile()
        {
            CreateMap<ShelfPutPostDTO, UpdateShelfCommand>();
            CreateMap<ShelfPutPostDTO, CreateShelfCommand>();
            CreateMap<Shelf, ShelfGetDTO>()
                .ForMember(shelfDTO => shelfDTO.Books, opt => opt.MapFrom(shelf => shelf.Books.Select(shelfBook => shelfBook.Book)));
            CreateMap<Shelf, ShelfDTO>();
        }
    }
}
