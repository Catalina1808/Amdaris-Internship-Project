namespace BookLoversProject.Domain.Domain
{
    public class Review: Entity
    {
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        public Review(string comment, User user, DateTime date)
        {
            Comment = comment;
            User = user;
            Date = date;
        }
    }
}
