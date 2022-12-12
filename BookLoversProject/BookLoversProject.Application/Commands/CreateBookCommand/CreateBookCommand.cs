﻿using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    public class CreateBookCommand: IRequest<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<int> AuthorsId { get; set; }

        public ICollection<int> GenresId { get; set; }
    }
}
