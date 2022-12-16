using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Application.DTO
{
    public class AuthorPutPostDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
