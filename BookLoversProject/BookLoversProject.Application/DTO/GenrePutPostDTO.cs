using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Application.DTO
{
    public class GenrePutPostDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
