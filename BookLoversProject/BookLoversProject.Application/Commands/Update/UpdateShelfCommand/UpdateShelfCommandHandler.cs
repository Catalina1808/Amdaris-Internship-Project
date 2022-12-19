using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateShelfCommand
{
    public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand, ShelfGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateShelfCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfGetDTO> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Shelf
            {
                Id = request.Id,
                Name = request.Name
            };

            await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.Id);
            _unitOfWork.ShelfRepository.UpdateShelf(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<ShelfGetDTO>(toUpdate);
        }
    }
}
