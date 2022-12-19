﻿using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);

        Task<Book> GetBookByIdAsync(int id);

        Task<ICollection<Book>> GetAllBooksAsync();

        void DeleteBook(Book book);

        Task UpdateBookAsync(Book book);
    }
}
