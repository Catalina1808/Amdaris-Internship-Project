using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO.BookDTOs
{
    public class BookGetDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Rating { get; set; }

        public ICollection<AuthorDTO> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<GenreDTO> Genres { get; set; }

        public ICollection<ShelfPutDTO> Shelves { get; set; }
    }
}
