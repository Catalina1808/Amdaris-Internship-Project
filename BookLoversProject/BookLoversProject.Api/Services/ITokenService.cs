using BookLoversProject.Application.DTO.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace BookLoversProject.Presentation.Services
{
    public interface ITokenService
    {
        string CreateToken(UserGetDTO user);
    }
}
