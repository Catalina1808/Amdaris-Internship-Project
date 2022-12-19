using BookLoversProject.Application.DTO.GenreDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateGenreCommand
{
    public class UpdateGenreCommand: IRequest<GenreGetDTO>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
