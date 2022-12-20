﻿using BookLoversProject.Application.DTO.AdminDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAdminCommand
{
    public class CreateAdminCommand : IRequest<AdminGetDTO>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}