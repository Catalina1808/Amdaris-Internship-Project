using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    public class TestClass
    {
        public static void Main()
        {
            NoAccountAuthor noAccountAuthor = new NoAccountAuthor(1, "noAccount1", new List<User>());
            AccountAuthor accountAuthor = new AccountAuthor(1, "emailAuthor1", "password1", "account1", new List<User>());
            AccountAuthor accountAuthor2 = new AccountAuthor(2, "emailAuthor2", "password2", "account2", new List<User>());
            List<Author> authors = new List<Author>();
            authors.Add(noAccountAuthor);
            authors.Add(accountAuthor);
            authors.Add(accountAuthor2);

            //one IEnumerable example
            IEnumerable<Author> enumAuthors = from author in authors where (author.GetType() == typeof(AccountAuthor)) select author;
            foreach (Author author in enumAuthors)
            {
                Console.WriteLine(author.Name);
            }

            List<Genre> genres = new List<Genre> {new Genre(1, "Drama"), new Genre(2, "Thriller")};
            Book book1 = new Book(1, "title1", "description", authors, genres);
            Book book2 = new Book(2, "title2", "description", authors, genres);

            Book book3 = (Book)book1.Clone(); //because Book class implements ICloneable interface
            Book book4 = book2;

            book3.Title = "title3";
            book4.Title = "title4";

            Shelf shelf = new Shelf(1, "shelf1");
            shelf.AddBook(book1);
            shelf.AddBook(book2);
            shelf.AddBook(book3);
            shelf.AddBook(book4);

            Console.WriteLine();

            foreach (Book book in shelf)  //because Shelf class implements IEnumerable interface
            {
                Console.WriteLine(book.Title);
            }

        }
    }
}
