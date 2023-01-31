using BookLoversProject.Application.DTO.GenreDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateGenreCommand
{
    public class CreateGenreCommand : IRequest<GenreGetDTO>
    {
        public string Name { get; set; }
    }
}
