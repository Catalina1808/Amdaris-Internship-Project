namespace BookLoversProject.Domain.Domain
{
    public class Reader : AbstractUser
    {
        private string firstName;
        private string lastName;

        public string Name
        {
            get
            {
                return firstName + " " + lastName;
            }
            set
            {
                int indexOfSpace = value.IndexOf(" ");
                if (indexOfSpace > 0)
                {
                    firstName = value.Substring(0, indexOfSpace);
                    lastName = value.Substring(indexOfSpace + 1);
                }
            }
        }
        public string ImagePath { get; set; }

        public ICollection<Shelf> BookShelves { get; }

        public ICollection<Reader> Friends { get; set; }

        public ICollection<ReaderAuthor> Authors { get; set; }

    }
}
