using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Application.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }

        public BookNotFoundException(string? message) : base(message)
        {
        }
    }
}
