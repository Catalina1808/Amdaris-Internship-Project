using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Update.UpdateShelfCommand;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ShelfProfile: Profile
    {
        public ShelfProfile()
        {
            CreateMap<ShelfPutDTO, UpdateShelfCommand>();
            CreateMap<ShelfPostDTO, CreateShelfCommand>();
            CreateMap<Shelf, ShelfGetDTO>()
                .ForMember(shelfDTO => shelfDTO.Books, opt => opt.MapFrom(shelf => shelf.Books.Select(shelfBook => shelfBook.Book)));
            CreateMap<Shelf, ShelfPutDTO>();
        }
    }
}
