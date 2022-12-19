using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;
using System;

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

            var genreBookLink = book.Genres
                     .SingleOrDefault(link => link.GenreId == request.GenreId && link.BookId == request.BookId);
            if (genreBookLink != null)
            {
                throw new ObjectAlreadyFoundException("Exception occurred! The link between the objects already exists!");
            }

            var newLink = new GenreBook { BookId = request.BookId, GenreId = request.GenreId };
            book.Genres.Add(newLink);

            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
        }
    }
}
