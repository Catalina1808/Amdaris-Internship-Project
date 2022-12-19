using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAdminCommand
{
    public class UpdateAdminCommand: IRequest<AdminGetDTO>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
