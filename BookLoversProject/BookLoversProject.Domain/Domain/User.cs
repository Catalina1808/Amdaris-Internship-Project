namespace BookLoversProject.Domain.Domain
{
    public class User : AbstractUser
    {
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

        public string ImagePath { get; set; }

        public ICollection<Shelf> BookShelves { get; }

        public ICollection<User> Friends { get; set; }

        public ICollection<UserAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
