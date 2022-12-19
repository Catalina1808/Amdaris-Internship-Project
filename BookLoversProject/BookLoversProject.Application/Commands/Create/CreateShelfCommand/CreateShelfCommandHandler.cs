using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateShelfCommand
{
    internal class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, ShelfGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShelfCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfGetDTO> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                return null;
            }

            var shelf = new Shelf
            {
                Name = request.Name
            };
            user.Shelves.Add(shelf);

            await _unitOfWork.ShelfRepository.AddShelfAsync(shelf);
            await _unitOfWork.Save();

            return _mapper.Map<ShelfGetDTO>(shelf);
        }
    }
}
