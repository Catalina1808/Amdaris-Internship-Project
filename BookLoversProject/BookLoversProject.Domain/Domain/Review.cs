namespace BookLoversProject.Domain.Domain
{
    public class Review: Entity
    {
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        //public Review(int id, string comment, User user, DateTime date)
        //{
        //    Id = id;
        //    Comment = comment;
        //    User = user;
        //    Date = date;
        //}
    }
}
