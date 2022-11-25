﻿namespace BookLoversProject.Domain.Domain
{
    [Serializable]
    public class Genre : Entity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}