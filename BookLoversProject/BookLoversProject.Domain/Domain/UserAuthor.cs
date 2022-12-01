namespace BookLoversProject.Domain.Domain
{
    public class UserAuthor
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
