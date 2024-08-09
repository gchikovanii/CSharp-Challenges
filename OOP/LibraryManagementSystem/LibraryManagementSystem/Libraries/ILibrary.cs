using LibraryManagementSystem.Books;
using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Libraries
{
    public interface ILibrary
    {
        Guid AddBook(Book book);
        string RemoveBook(string title);
        Dictionary<Book, BookStatus> GetAllBooks();
        Book GetBook(string Title);
    }
}
