using BookLoversProject.Application.DTO.BookDTOs;

namespace BookLoversProject.Application.DTO.ShelfDTOs
{
    public class ShelfGetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<BookGetDTO> Books { get; set; }
    }
}
