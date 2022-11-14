namespace BookLoversProject.Domain.Domain
{
    public interface IAuthor
    {
        string Name { get; set; }
        List<User> Followers { get; set; }
    }
}
