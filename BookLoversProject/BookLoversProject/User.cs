using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { private get;  set; }

        public User(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public virtual string GreetingMessage()
        {
            return "Hello, " + Email + "!";
        }

    }
}
