using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAuthorFromBookCommand
{
    public class DeleteAuthorFromBookCommandHandler : IRequestHandler<DeleteAuthorFromBookCommand, BookGetDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public DeleteAuthorFromBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(DeleteAuthorFromBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);

            var bookAuthorLink = book.Authors.SingleOrDefault(link => link.AuthorId == request.AuthorId && link.BookId == request.BookId);

            if(bookAuthorLink == null)
            {
                throw new ObjectNotFoundException("Exception occurred! The link between the objects does not exist!");
            }
            book.Authors.Remove(bookAuthorLink);

            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
        }
    }
}
