using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateUserCommand
{
    public class UpdateUserCommand: IRequest<User>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
