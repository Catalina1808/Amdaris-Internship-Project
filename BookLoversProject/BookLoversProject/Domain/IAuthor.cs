using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Domain
{
    internal interface IAuthor
    {
        string Name { get; set; }
        List<User> Followers { get; set; }
    }
}
