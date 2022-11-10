using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Domain
{
    internal class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        public Review(int id, string comment, User user, DateTime date)
        {
            Id = id;
            Comment = comment;
            User = user;
            Date = date;
        }
    }
}
