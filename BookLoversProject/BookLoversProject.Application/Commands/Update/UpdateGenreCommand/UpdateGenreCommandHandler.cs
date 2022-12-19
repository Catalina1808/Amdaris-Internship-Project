using AutoMapper;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateGenreCommand
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreGetDTO> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Genre
            {
                Id = request.Id,
                Name = request.Name
            };

            await _unitOfWork.GenreRepository.UpdateGenreAsync(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<GenreGetDTO>(toUpdate);
        }
    }
}
