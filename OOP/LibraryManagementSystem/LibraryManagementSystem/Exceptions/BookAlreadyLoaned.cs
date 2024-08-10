namespace LibraryManagementSystem.Exceptions
{
    public class BookAlreadyLoaned : Exception
    {
        public BookAlreadyLoaned(string message) : base(message)
        {
        }
    }
}
