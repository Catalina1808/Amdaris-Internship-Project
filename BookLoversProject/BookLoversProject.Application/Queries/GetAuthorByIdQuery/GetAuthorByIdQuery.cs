using BookLoversProject.Application.DTO.AuthorDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQuery : IRequest<AuthorGetDTO>
    {
        public int Id { get; set; }
    }
}
