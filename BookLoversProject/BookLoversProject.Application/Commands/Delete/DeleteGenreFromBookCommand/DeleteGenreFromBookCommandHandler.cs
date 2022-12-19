using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteGenreFromBookCommand
{
    public class DeleteGenreFromBookCommandHandler : IRequestHandler<DeleteGenreFromBookCommand, BookGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGenreFromBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(DeleteGenreFromBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.GenreId);

            var genreBookLink = book.Genres.SingleOrDefault(link => link.GenreId == request.GenreId && link.BookId == request.BookId);

            if (genreBookLink == null)
            {
                throw new ObjectNotFoundException("Exception occurred! The link between the objects does not exist!");
            }

            book.Genres.Remove(genreBookLink);
            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
        }
    }
}
