namespace BookLoversProject.Domain.Domain
{
    public class Author : Reader
    {
        public string Description { get; set; }
        public ICollection<IUser> Followers { get; set; }
    }
}
