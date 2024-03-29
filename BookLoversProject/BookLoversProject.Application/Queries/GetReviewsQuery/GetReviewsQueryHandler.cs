﻿using AutoMapper;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewsQuery
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<ReviewGetDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetReviewsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewGetDTO>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ReviewRepository.GetAllReviewsAsync();

            return result.Select(review => _mapper.Map<ReviewGetDTO>(review));
        }
    }
}
