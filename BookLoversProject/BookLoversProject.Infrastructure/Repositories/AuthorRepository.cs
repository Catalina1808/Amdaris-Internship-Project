﻿using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> authors;

        public AuthorRepository(List<Author> authors)
        {
            this.authors = authors;
        }

        public Author AddAuthor(Author author)
        {
            authors.Add(author);
            return author;
        }

        public void AddFollowerToAuthor(Reader follower, Author author)
        {
            var readerAutor = new ReaderAuthor();
            readerAutor.Author = author;
            readerAutor.Reader = follower;
            readerAutor.AuthorId = author.Id;
            readerAutor.ReaderId = follower.Id;

            author.Followers.Add(readerAutor);
            follower.Authors.Add(readerAutor);
        }

        public void DeleteAuthor(Author author)
        {
            authors.Remove(author);
        }

        public void DeleteFollowerFromAuthor(Reader follower, Author author)
        {
            var readerAuthor = author.Followers.FirstOrDefault(item => item.Reader == follower);

            if (!author.Followers.Remove(readerAuthor))
            {
                throw new Exception("Follower not found!");
            }
        }

        public Author GetAuthorById(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return authors;
        }
    }
}