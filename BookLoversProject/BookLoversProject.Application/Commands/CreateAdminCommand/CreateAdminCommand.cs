using MediatR;

namespace BookLoversProject.Application.Commands.CreateAdminCommand
{
    public class CreateAdminCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
