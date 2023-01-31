using AutoMapper;
using BookLoversProject.Application.DTO.ReviewDTOs;
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
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);

            var review = new Review
            {
                Comment = request.Comment,
                Date = DateTime.Now,
                Rating = request.Rating,
                BookId = request.BookId,
                UserId = request.UserId
            };

            book.Reviews.Add(review);

            await _unitOfWork.Save();

            return _mapper.Map<ReviewGetDTO>(review);
        }
    }
}
