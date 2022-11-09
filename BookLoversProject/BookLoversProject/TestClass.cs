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
            List<IAuthor> authors = new List<IAuthor>();
            authors.Add(noAccountAuthor);
            authors.Add(accountAuthor);
            authors.Add(accountAuthor2);

            //one IEnumerable example
            IEnumerable<IAuthor> enumAuthors = from author in authors where (author.GetType() == typeof(AccountAuthor)) select author;
            foreach (IAuthor author in enumAuthors)
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


#if DEBUG

            try
            {
                book1.AddReview(null);
            }
            catch (ReviewNotFoundException reviewException)
            {
                Console.WriteLine(reviewException.Message);
            }
            catch
            {
                Console.WriteLine("Exception occured!");
            }

#endif


            Console.WriteLine();
            Shelf shelf = new Shelf(1, "shelf1");
         

            try
            {
                shelf.AddBook(book1);
                shelf.AddBook(book2);
                shelf.AddBook(book3);
                shelf.AddBook(null);
                shelf.AddBook(book4);
            }
            catch (BookNotFoundException bookException)
            {
                Console.WriteLine(bookException.Message);
            }
            catch
            {
                Console.WriteLine("Exception occured!");
            }
            finally
            {
                foreach (Book book in shelf)  //because Shelf class implements IEnumerable interface
                {
                    Console.WriteLine(book.Title);
                }
            }

        }
    }
}
