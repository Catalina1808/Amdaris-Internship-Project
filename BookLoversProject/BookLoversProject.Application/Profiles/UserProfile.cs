using AutoMapper;
using BookLoversProject.Application.Queries.GetUsersQuery;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
