using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    internal class NoAccountAuthor : Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Followers { get; set; }

        public NoAccountAuthor(int id, string name, List<User> followers)
        {
            Id = id;    
            Name = name;
            Followers = followers;
        }

        public NoAccountAuthor(int id, string name)
        {
            Id = id;
            Name = name;
            Followers = new List<User>();
        }

        public void AddFollower(User user)
        {
            Followers.Add(user);
        }

        public void DeleteFollower(User user)
        {
            Followers.Remove(user);
        }
    }
}
