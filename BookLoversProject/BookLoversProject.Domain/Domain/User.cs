namespace BookLoversProject.Domain.Domain
{
    public class User: Entity
    {
        public string Email { get; set; }
        public string Password { private get; set; }

        //public User(int id, string email, string password)
        //{
        //    Id = id;
        //    Email = email;
        //    Password = password;
        //}
        public virtual string GreetingMessage()
        {
            return "Hello, " + Email + "!";
        }
    }
}
