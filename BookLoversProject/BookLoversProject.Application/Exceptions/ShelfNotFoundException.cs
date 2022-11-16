using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversProject.Application.Exceptions
{
    public class ShelfNotFoundException : Exception
    {
        public ShelfNotFoundException()
        {
        }

        public ShelfNotFoundException(string? message) : base(message)
        {
        }
    }
}
