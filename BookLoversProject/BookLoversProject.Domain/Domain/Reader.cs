namespace BookLoversProject.Domain.Domain
{
    public class Reader : Entity, IUser
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

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
