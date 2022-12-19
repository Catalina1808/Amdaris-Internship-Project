using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateGenreCommand
{
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreGetDTO> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Name = request.Name
            };

            await _unitOfWork.GenreRepository.AddGenreAsync(genre);
            await _unitOfWork.Save();

            return _mapper.Map<GenreGetDTO>(genre);
        }
    }
}
