using AutoMapper;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteBookFromShelfCommand
{
    public class DeleteBookFromShelfCommandHandler : IRequestHandler<DeleteBookFromShelfCommand, ShelfGetDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public DeleteBookFromShelfCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfGetDTO> Handle(DeleteBookFromShelfCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            var shelf = await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.ShelfId);

            var shelfBookLink = book.Shelves.SingleOrDefault(link => link.ShelfId == request.ShelfId && link.BookId == request.BookId);

            if (shelfBookLink == null)
            {
                throw new ObjectNotFoundException("Exception occurred! The link between the objects does not exist!");
            }

            shelf.Books.Remove(shelfBookLink);

            await _unitOfWork.Save();

            return _mapper.Map<ShelfGetDTO>(shelf);
        }
    }
}
