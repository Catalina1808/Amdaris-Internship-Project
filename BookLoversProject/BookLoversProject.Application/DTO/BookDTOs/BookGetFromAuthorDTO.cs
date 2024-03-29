﻿using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO.BookDTOs
{
    public class BookGetFromAuthorDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<GenreDTO> Genres { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
