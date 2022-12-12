﻿using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Infrastructure.InMemoryRepository
{
    public class InMemoryGenreRepository : IGenreRepository
    {
        private readonly ICollection<Genre> _genres;

        public InMemoryGenreRepository(ICollection<Genre> genres)
        {
            _genres = genres;
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            _genres.Add(genre);
            return genre;
        }

        public async Task DeleteGenre(int id)
        {
            var genre = _genres.SingleOrDefault(x => x.Id == id);
            if (genre == null)
            {
                throw new ArgumentNullException("There is no genre with the given ID.");
            }
            _genres.Remove(genre);
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            return _genres.ToList();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var genre = _genres.SingleOrDefault(x => x.Id == id);
            if (genre == null)
            {
                throw new Exception("Exception occured, genre not found!");
            }
            return genre;
        }

        public async Task AddBookToGenre(GenreBook genreBook, int genreId)
        {
            var genre = _genres.SingleOrDefault(x => x.Id == genreId);
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
            var genre = _genres.SingleOrDefault(x => x.Id == genreId);
            if (genre == null || !genre.Books.Remove(genreBook))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
