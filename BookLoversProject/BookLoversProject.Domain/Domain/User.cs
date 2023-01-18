using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BookLoversProject.Domain.Domain
{
    public class User: IdentityUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                int indexOfSpace = value.IndexOf(" ");
                if (indexOfSpace > 0)
                {
                    FirstName = value.Substring(0, indexOfSpace);
                    LastName = value.Substring(indexOfSpace + 1);
                }
            }
        }

        [AllowNull]
        public string ImagePath { get; set; }

        public ICollection<Shelf> Shelves { get; set; }

        public ICollection<UserAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
