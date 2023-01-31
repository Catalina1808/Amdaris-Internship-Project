using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommandHandler : IRequestHandler<AddAuthorToBookCommand, BookGetDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public AddAuthorToBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(AddAuthorToBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);

            var bookAuthorLink = book.Authors
                .SingleOrDefault(link => link.AuthorId == request.AuthorId && link.BookId == request.BookId);
            if (bookAuthorLink != null)
            {
                throw new ObjectAlreadyFoundException("Exception occurred! The link between the objects already exists!");
            }

            var newLink = new BookAuthor { BookId = request.BookId, AuthorId = request.AuthorId };
            book.Authors.Add(newLink);

            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
        }
    }
}
