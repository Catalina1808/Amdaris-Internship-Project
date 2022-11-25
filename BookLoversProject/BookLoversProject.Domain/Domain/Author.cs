namespace BookLoversProject.Domain.Domain
{
    public class Author : Entity, IUser
    {
        public string Name { get; set; }
        public ICollection<IUser> Followers { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
