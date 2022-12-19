using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateReviewCommand
{
    public class CreateReviewCommandHander : IRequestHandler<CreateReviewCommand, ReviewGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHander(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewGetDTO> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Comment = request.Comment,
                Date = DateTime.Now
            };

            await _unitOfWork.ReviewRepository.AddReviewAsync(review);
            await _unitOfWork.Save();

            return _mapper.Map<ReviewGetDTO>(review);
        }
    }
}
