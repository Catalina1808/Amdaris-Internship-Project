using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class ShelfProfile: Profile
    {
        public ShelfProfile()
        {
            CreateMap<ShelfPutPostDTO, CreateShelfCommand>();
            CreateMap<ShelfDTO, Shelf>();
            CreateMap<Shelf, ShelfDTO>();
        }
    }
}
