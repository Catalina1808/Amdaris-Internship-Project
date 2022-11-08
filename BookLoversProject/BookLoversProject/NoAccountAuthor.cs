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
    }
}
