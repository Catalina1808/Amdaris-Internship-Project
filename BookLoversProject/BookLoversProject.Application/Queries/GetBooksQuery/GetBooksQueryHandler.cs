using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksQuery
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IBookRepository repository;

        public GetBooksQueryHandler(IBookRepository repository)
        {
            this.repository = repository;   
        }
        public Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetAllBooks().Select(p => new BookDTO
            { 
                Id = p.Id,
                Title = p.Title,
                Description = p.Description 
            });
            return Task.FromResult(result);
        }
    }
}
