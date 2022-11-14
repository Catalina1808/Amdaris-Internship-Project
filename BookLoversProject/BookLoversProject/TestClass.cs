using BookLoversProject.Domain.Domain;

namespace BookLoversProject
{
    public class TestClass
    {
        public static void Main()
        {
            NoAccountAuthor noAccountAuthor = new NoAccountAuthor
            {
                Id = 1,
                Name = "noAccount1",
                Followers = new List<User>()
            };
            AccountAuthor accountAuthor = new AccountAuthor
            {
                Id = 1,
                Email = "emailAuthor1",
                Password = "password1",
                Name = "account1",
                Followers = new List<User>()
            };
            List<IAuthor> authors = new List<IAuthor>();
            authors.Add(noAccountAuthor);
            authors.Add(accountAuthor);

            //one IEnumerable example
            IEnumerable<IAuthor> enumAuthors = from author in authors where (author.GetType() == typeof(AccountAuthor)) select author;
            foreach (IAuthor author in enumAuthors)
            {
                Console.WriteLine(author.Name);
            }

            List<Genre> genres = new List<Genre> {
                new Genre
                {
                    Id= 1,
                    Name= "Drama",
                },
                new Genre
                {
                    Id= 2,
                    Name= "Thriller",
                }
            };

            Book book1 = new Book
            {
                Id = 1,
                Title = "title1",
                Description = "description",
                AuthorList = authors,
                GenreList = genres
            };
            Book book2 = new Book
            {
                Id = 2,
                Title = "title2",
                Description = "description",
                AuthorList = authors,
                GenreList = genres
            };

            Book book3 = (Book)book1.Clone(); //because Book class implements ICloneable interface
            Book book4 = book2;

            book3.Title = "title3";
            book4.Title = "title4";


            //#if DEBUG

            //            try
            //            {
            //                book1.AddReview(null);
            //            }
            //            catch (ReviewNotFoundException reviewException)
            //            {
            //                Console.WriteLine(reviewException.Message);
            //            }
            //            catch
            //            {
            //                Console.WriteLine("Exception occured!");
            //            }

            //#endif


            //            Console.WriteLine();
            //            Shelf shelf = new Shelf(1, "shelf1");


            //            try
            //            {
            //                shelf.AddBook(book1);
            //                shelf.AddBook(book2);
            //                shelf.AddBook(book3);
            //                shelf.AddBook(null);
            //                shelf.AddBook(book4);
            //            }
            //            catch (BookNotFoundException bookException)
            //            {
            //                Console.WriteLine(bookException.Message);
            //            }
            //            catch
            //            {
            //                Console.WriteLine("Exception occured!");
            //            }
            //            finally
            //            {
            //                foreach (Book book in shelf)  //because Shelf class implements IEnumerable interface
            //                {
            //                    Console.WriteLine(book.Title);
            //                }
            //            }

        }
    }
}
