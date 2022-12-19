using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateAdminCommand;
using BookLoversProject.Application.Commands.Update.UpdateAdminCommand;
using BookLoversProject.Application.DTO.AdminDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminPutPostDTO, UpdateAdminCommand>();
            CreateMap<AdminPutPostDTO, CreateAdminCommand>();
            CreateMap<Admin, AdminGetDTO>();
        }
    }
}
