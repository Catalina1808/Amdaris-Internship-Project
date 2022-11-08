using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    internal class Reader : User
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<Shelf> BookShelves { get;}
        public List<Reader> Friends { get; set; }

        public Reader(int id, string email, string password, string name, string imagePath, List<Shelf> bookShelves)
         : base(id, email, password)
        {
            Name = name;
            ImagePath = imagePath;
            BookShelves = bookShelves;
            Friends = new List<Reader>();
        }

        //override
        public override string GreetingMessage()
        {
            return "Hello, " + Name + "!";
        }

        public void AddShelf(Shelf shelf)
        {
            BookShelves.Add(shelf);
        }

        public void DeleteShelf(Shelf shelf)
        {
            BookShelves.Remove(shelf);
        }

    }
}
