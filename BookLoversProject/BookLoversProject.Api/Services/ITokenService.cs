using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Domain.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookLoversProject.Presentation.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, IList<string> roles);
    }
}
