namespace BookLoversProject.Domain.Domain
{
    public abstract class AbstractUser : Entity
    {
        public string IdentityId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
