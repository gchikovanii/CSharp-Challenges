using System;
using System.Collections.Generic;
using System.Linq;
namespace LibraryManagementSystem.Exceptions
{
    public class PenaltyExeption : Exception
    {
        public PenaltyExeption(string message): base(message)
        {
        }
    }
}
