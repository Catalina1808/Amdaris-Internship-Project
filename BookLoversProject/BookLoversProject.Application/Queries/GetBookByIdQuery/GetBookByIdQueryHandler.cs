﻿using AutoMapper;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<BookDTO>(await _unitOfWork.BookRepository.GetBookById(request.Id));
            return result;
        }
    }
}
