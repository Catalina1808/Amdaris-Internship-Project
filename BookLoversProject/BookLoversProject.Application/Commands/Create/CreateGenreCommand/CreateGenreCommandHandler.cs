using AutoMapper;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.Exceptions;
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
            var genres = await _unitOfWork.GenreRepository.GetAllGenresAsync();
            if(genres.Any(genre => genre.Name.ToLower() == request.Name.ToLower()))
            {
                throw new ObjectAlreadyFoundException("Exception occurred! A genre with this name already exists!");
            }

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
