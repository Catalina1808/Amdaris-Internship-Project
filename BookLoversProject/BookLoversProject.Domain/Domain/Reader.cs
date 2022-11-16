namespace BookLoversProject.Domain.Domain
{
    public class Reader : User
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

        public List<Shelf> BookShelves { get; }

        public List<Reader> Friends { get; set; }

        //override
        public override string GreetingMessage()
        {
            return "Hello, " + Name + "!";
        }

        public Reader(string email, string password, string firstName, string lastName)
         : base(email, password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Friends = new List<Reader>();
            BookShelves = new List<Shelf>();
        }

    }
}
