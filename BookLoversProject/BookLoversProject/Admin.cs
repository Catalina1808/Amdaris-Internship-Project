using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject
{
    internal class Admin : User
    {
        public Admin(int id, string email, string password) : base(id, email, password)
        {
        }

        public void AddBook(Book book)
        {

        }

        public void DeleteBook(Book book)
        {

        }

        public void UpdateBook(Book book)
        {

        }
    }
}
