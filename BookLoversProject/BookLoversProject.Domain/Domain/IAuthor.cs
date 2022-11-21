namespace BookLoversProject.Domain.Domain
{
    public interface IAuthor
    {
        string Name { get; set; }
        ICollection<User> Followers { get; set; }
    }
}
