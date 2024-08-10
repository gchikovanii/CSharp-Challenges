using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Exceptions
{
    public class BookLimitException : Exception
    {
        public BookLimitException(string message): base(message)
        {
        }
    }
}
