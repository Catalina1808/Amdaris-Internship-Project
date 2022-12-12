//using BookLoversProject.Application.Queries.GetBooksQuery;
//using BookLoversProject.Domain.Domain;
//using BookLoversProject.Infrastructure;
//using Microsoft.EntityFrameworkCore;

//var optionsBuilder = new DbContextOptionsBuilder();
//optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;Database=BookLovers;Integrated Security=True;TrustServerCertificate=True;");

//var appContext = new ApplicationContext(optionsBuilder.Options);

//var book1 = await appContext.Books
//    .Select(book1 => new BookDTO
//    {
//        Title = book1.Title,
//        Description = book1.Description
//    })
//    .Where(book1 => book1.Title == "Ugly love")
//    .FirstOrDefaultAsync();

//var booksAndReviews = appContext.Books
//    .SelectMany(book => book.Reviews, (b, r) => new BookDTO
//    {
//        Title = b.Title,
//        Description = r.Comment
//    })
//    .ToList();

//var orderedGenres = await appContext.Genres
//    .OrderBy(genre => genre.Name)
//    .Take(2)
//    .ToListAsync();

//var orderedAuthors = await appContext.Authors
//    .OrderBy(author => author.Name)
//    .Skip(1)
//    .ToListAsync();

//var booksAndAuthors = await appContext.Books
//    .Include(book => book.Authors)
//    .ThenInclude(bookAuthor => bookAuthor.Author)
//    .ToListAsync();

//var usersAndAuthors = await appContext.Users
//    .Include(user => user.Authors)
//    .ThenInclude(userAuthor => userAuthor.Author)
//    .ToListAsync();

//var booksAndGenres = await appContext.Books
//    .Include(book => book.Genres)
//    .ThenInclude(genreBook => genreBook.Genre)
//    .OrderBy(genre => genre.Title)
//    .ToListAsync();

//foreach (var book in booksAndGenres)
//{
//    Console.WriteLine(book.Id + " " + book.Title);

//    foreach (var genre in book.Genres)
//    {
//        Console.WriteLine(genre.Genre.Name);
//    }
//}

//var groupedBooks = await appContext.Genres
//    .Include(genre => genre.Books)
//    .ThenInclude(genreBook => genreBook.Book)
//    .GroupBy(genre => genre.Name)
//    .ToListAsync();

//IEnumerable<Review> newReviews = appContext.Reviews
//    .Where(review => review.Date > DateTime.Now.AddMonths(-1))
//    .Take(2);

//IQueryable<Review> oldReviews = appContext.Reviews
//    .Where(review => review.Date < DateTime.Now.AddMonths(-1))
//    .Take(2);

//Console.ReadKey();
