using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAdminCommand
{
    public class DeleteAdminCommand: IRequest<Admin>
    {
        public int Id { get; set; }
    }
}
