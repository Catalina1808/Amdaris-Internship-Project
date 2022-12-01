using MediatR;

namespace BookLoversProject.Application.Commands.CreateReaderCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
    }
}
