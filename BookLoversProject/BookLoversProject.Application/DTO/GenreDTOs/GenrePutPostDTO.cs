using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Application.DTO.GenreDTOs
{
    public class GenrePutPostDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
