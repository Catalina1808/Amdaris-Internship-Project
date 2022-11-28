namespace BookLoversProject.Domain.Domain
{
    public class Reader : AbstractUser
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

        public ICollection<Reader> Friends { get; set; }

        public ICollection<ReaderAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
