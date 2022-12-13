using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAdminCommand
{
    public class CreateAdminCommand : IRequest<Admin>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
