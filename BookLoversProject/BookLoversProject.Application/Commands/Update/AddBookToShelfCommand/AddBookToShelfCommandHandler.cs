using AutoMapper;
using BookLoversProject.Application.DTO.ShelfDTOs;
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
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            var shelf = await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.ShelfId);

            var shelfBookLink = new ShelfBook { BookId = request.BookId, ShelfId = request.ShelfId };
            shelf.Books.Add(shelfBookLink);

            await _unitOfWork.Save();

            return _mapper.Map<ShelfGetDTO>(shelf);
        }
    }
}
