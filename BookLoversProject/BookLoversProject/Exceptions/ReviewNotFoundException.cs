using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Exceptions
{
    internal class ReviewNotFoundException : Exception
    {
        public ReviewNotFoundException()
        {
        }

        public ReviewNotFoundException(string? message) : base(message)
        {
        }
    }
}
