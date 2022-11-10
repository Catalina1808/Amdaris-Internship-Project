using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Domain
{
    //implementation of IEnumerable
    internal class Shelf : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; }

        public Shelf(int id, string name)
        {
            Id = id;
            Name = name;
            Books = new List<Book>();
        }

        public Book GetBook(int bookId)
        {
            foreach (Book book in Books)
            {
                if (book.Id == bookId)
                {
                    return book;
                }
            }

            throw new Exceptions.BookNotFoundException("Exception occured, book not found!");
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Exception occured, book not defined!");
            }
            Books.Add(book);
        }

        //overloading
        public void AddBook(int id, string title, string description, List<IAuthor> authorList, List<Genre> genreList)
        {
            Book book = new Book(id, title, description, authorList, genreList);
            Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Exception occured, book not defined!");
            }
            Books.Remove(book);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
