using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    //implementation of ICloneable
    internal class Book: ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Author> AuthorList { get; set; }
        public List<Review> ReviewList { get; }
        public List<Genre> GenreList { get; set; }

        public Book(int id, string title, string description, List<Author> authorList, List<Genre> genreList)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorList = authorList;
            ReviewList = new List<Review>();
            GenreList = genreList;
        }

        public void AddReview(Review review)
        {
            ReviewList.Add(review);
        }

        public void DeleteReview(Review review)
        {
            ReviewList.Remove(review);
        }

        public object Clone()
        {
            Book clone = new Book(Id, Title, Description, AuthorList, GenreList);
            return clone;
        }
    }
}
