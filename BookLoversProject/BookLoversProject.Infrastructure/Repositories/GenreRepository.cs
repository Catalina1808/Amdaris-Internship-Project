﻿using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _context;

        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            return genre;
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if(genre == null)
            {
                throw new ArgumentNullException("There is no genre with the given ID.");
            }
            _context.Genres.Remove(genre);
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                throw new Exception("Exception occured, genre not found!");
            }
            return genre;
        }

        public async Task AddBookToGenre(GenreBook genreBook, int genreId)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == genreId);
            if (genre != null && genreBook != null)
            {
                genre.Books.Add(genreBook);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteBookFromGenre(GenreBook genreBook, int genreId)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == genreId);
            if(genre == null || !genre.Books.Remove(genreBook))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
