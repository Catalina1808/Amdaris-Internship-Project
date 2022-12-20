﻿using BookLoversProject.Application.DTO.AuthorDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddFollowerToAuthorCommand
{
    public class AddFollowerToAuthorCommand: IRequest<AuthorGetDTO>
    {
        public int UserId { get; set; }

        public int AuthorId { get; set; }
    }
}