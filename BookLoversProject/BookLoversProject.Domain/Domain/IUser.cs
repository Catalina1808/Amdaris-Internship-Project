namespace BookLoversProject.Domain.Domain
{
    public abstract class AbstractUser : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
