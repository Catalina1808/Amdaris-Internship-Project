using AutoMapper;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateReviewCommand
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewGetDTO> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Review
            {
                Id = request.Id,
                Comment = request.Comment,
                Date = DateTime.Now,
                Rating = request.Rating
            };

            await _unitOfWork.ReviewRepository.UpdateReviewAsync(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<ReviewGetDTO>(toUpdate);
        }
    }
}
