namespace LibraryManagementSystem.Exceptions
{
    public class AlreadyBorrowedException : Exception
    {
        public AlreadyBorrowedException(string message): base(message) { }
    }
}
