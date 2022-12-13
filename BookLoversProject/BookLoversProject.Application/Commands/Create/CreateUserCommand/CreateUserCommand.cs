using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateUserCommand
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
