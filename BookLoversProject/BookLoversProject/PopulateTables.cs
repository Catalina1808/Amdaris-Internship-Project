using BookLoversProject.Application.Commands.CreateAuthorCommand;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure;
using BookLoversProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var appContext = new ApplicationContext();

Author author1 = new Author
{
    Name = "Colleen Hoover",
    Description = "International and #1 New York Times bestselling author of romance, YA, thriller, women's fiction and paranormal romance."
};
Author author2 = new Author
{
    Name = "Rupi Kaur",
    Description = "A breakout literary phenomenon and #1 New York Times Bestselling Author, Rupi Kaur wrote, illustrated, and self-published her first poetry collection, 'milk and honey' in 2014."
};
Author author3 = new Author
{
    Name = "Veronica Roth",
    Description = "Veronica Roth is the New York Times best-selling author of Poster Girl, Chosen Ones, the short story collection The End and Other Beginnings, the Divergent series, and the Carve the Mark duology."
};

Book book1 = new Book
{
    Title = "Ugly love",
    Description = "When Tate Collins meets airline pilot Miles Archer, she knows it isn’t love at first sight. They wouldn’t even go so far as to consider themselves friends. The only thing Tate and Miles have in common is an undeniable mutual attraction."
};
Book book2 = new Book
{
    Title = "Milk and Honey",
    Description = "Milk and honey is a collection of poetry and prose about survival. About the experience of violence, abuse, love, loss, and femininity. It is split into four chapters, and each chapter serves a different purpose. Deals with a different pain. Heals a different heartache."
};
Book book3 = new Book
{
    Title = "Divergent",
    Description = "In Beatrice Prior''s dystopian Chicago world, society is divided into five factions, each dedicated to the cultivation of a particular virtue—Candor (the honest), Abnegation (the selfless), Dauntless (the brave), Amity (the peaceful), and Erudite (the intelligent)."
};

Genre genre1 = new Genre
{
    Name = "Contemporary"
};
Genre genre2 = new Genre
{
    Name = "Poetry"
};
Genre genre3 = new Genre
{
    Name = "Fiction"
};

User user1 = new User
{
    FirstName = "Catalina",
    LastName = "Gramada",
    Email = "catalina.g1808@gmail.com",
    Password = "123456"
};

Review review1 = new Review
{
    Comment = "Great book!",
    Date = DateTime.Now
};

BookAuthor ba1 = new BookAuthor
{
    Book = book1,
    Author = author1
};
BookAuthor ba2 = new BookAuthor
{
    Book = book2,
    Author = author2
};
BookAuthor ba3 = new BookAuthor
{
    Book = book3,
    Author = author3
};

GenreBook gb1 = new GenreBook
{
    Genre = genre1,
    Book = book1,
};
GenreBook gb2 = new GenreBook
{
    Genre = genre2,
    Book = book2,
};
GenreBook gb3 = new GenreBook
{
    Genre = genre3,
    Book = book3,
};
GenreBook gb4 = new GenreBook
{
    Genre = genre3,
    Book = book1,
};

UserAuthor ua1 = new UserAuthor
{
    Author = author1,
    User = user1
};
UserAuthor ua2 = new UserAuthor
{
    Author = author2,
    User = user1
};

book1.Reviews = new List<Review> { review1 };
user1.Reviews = new List<Review> { review1 };

author1.Followers = new List<UserAuthor> { ua1 };
author2.Followers = new List<UserAuthor> { ua2 };

book1.Authors = new List<BookAuthor> { ba1 };
book2.Authors = new List<BookAuthor> { ba2 };
book3.Authors = new List<BookAuthor> { ba3 };

book1.Genres = new List<GenreBook> { gb1, gb4 };
book2.Genres = new List<GenreBook> { gb2 };
book3.Genres = new List<GenreBook> { gb3 };

appContext.Books.Add(book1);
appContext.Books.Add(book2);
appContext.Books.Add(book3);

await appContext.SaveChangesAsync();
