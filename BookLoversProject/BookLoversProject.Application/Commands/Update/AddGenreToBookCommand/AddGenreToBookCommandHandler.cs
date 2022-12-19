using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddGenreToBookCommand
{
    public class AddGenreToBookCommandHandler : IRequestHandler<AddGenreToBookCommand, BookGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddGenreToBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(AddGenreToBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.GenreId);

            var genreBookLink = new GenreBook { BookId = request.BookId, GenreId = request.GenreId };

            book.Genres.Add(genreBookLink);
            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
        }
    }
}
