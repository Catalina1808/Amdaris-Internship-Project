﻿using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateBookCommand
{
    public class UpdateBookCommand: IRequest<BookGetDTO>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}