﻿using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Queries.GetUsersQuery
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Shelf> BookShelves { get; }

        public ICollection<User> Friends { get; set; }

        public ICollection<UserAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}