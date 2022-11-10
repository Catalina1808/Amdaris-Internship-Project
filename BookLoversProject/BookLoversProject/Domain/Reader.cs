using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Domain
{
    internal class Reader : User
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

        public Reader(int id, string email, string password, string firstName, string lastName, string imagePath)
         : base(id, email, password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            ImagePath = imagePath;
            Friends = new List<Reader>();
            BookShelves = new List<Shelf>();
        }

        //override
        public override string GreetingMessage()
        {
            return "Hello, " + Name + "!";
        }

        public Shelf GetShelf (int shelfId)
        {
            foreach (Shelf shelf in BookShelves)
            {
                if (shelf.Id == shelfId)
                {
                    return shelf;
                }
            }

            throw new Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
        }

        public void AddShelf(Shelf shelf)
        {
            if (shelf == null)
            {
                throw new ArgumentNullException("Exception occured, shelf not defined!");
            }
            BookShelves.Add(shelf);
        }

        public void DeleteShelf(Shelf shelf)
        {
            if (shelf == null)
            {
                throw new ArgumentNullException("Exception occured, shelf not defined!");
            }
            BookShelves.Remove(shelf);
        }

    }
}
