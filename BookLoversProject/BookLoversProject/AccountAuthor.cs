using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    internal class AccountAuthor : User, Author
    {
        public string Name { get; set ; }
        public List<User> Followers { get; set; }
 
        public AccountAuthor(int id, string email, string password, string name, List<User> followers) : base(id, email, password)
        {
            Name = name;
            Followers = followers;
        }

    }
}
