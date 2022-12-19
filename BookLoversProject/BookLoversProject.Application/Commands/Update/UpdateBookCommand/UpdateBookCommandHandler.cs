using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description
            };

            await _unitOfWork.BookRepository.UpdateBookAsync(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(toUpdate);
        }
    }
}
