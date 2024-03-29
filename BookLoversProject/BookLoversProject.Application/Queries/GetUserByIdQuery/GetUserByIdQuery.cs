﻿using BookLoversProject.Application.DTO.UserDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<UserGetDTO>
    {
        public string Id { get; set; }
    }
}
