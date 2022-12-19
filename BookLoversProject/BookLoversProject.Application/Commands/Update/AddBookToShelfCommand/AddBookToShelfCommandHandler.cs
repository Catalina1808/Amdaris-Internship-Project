using AutoMapper;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddBookToShelfCommand
{
    public class AddBookToShelfCommandHandler : IRequestHandler<AddBookToShelfCommand, ShelfGetDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public AddBookToShelfCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfGetDTO> Handle(AddBookToShelfCommand request, CancellationToken cancellationToken)
        {
            var shelf = await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.ShelfId);
            await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);

            var shelfBookLink = shelf.Books
                     .SingleOrDefault(link => link.ShelfId == request.ShelfId && link.BookId == request.BookId);
            if (shelfBookLink != null)
            {
                throw new ObjectAlreadyFoundException("Exception occurred! The link between the objects already exists!");
            }

            var newLink = new ShelfBook { BookId = request.BookId, ShelfId = request.ShelfId };
            shelf.Books.Add(newLink);

            await _unitOfWork.Save();

            return _mapper.Map<ShelfGetDTO>(shelf);
        }
    }
}
