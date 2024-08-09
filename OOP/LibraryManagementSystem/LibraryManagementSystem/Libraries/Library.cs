using LibraryManagementSystem.Books;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Exceptions;

namespace LibraryManagementSystem.Libraries
{
    public class Library : ILibrary
    {
        //Has A relatioship
        private readonly Dictionary<Book, BookStatus> Books;

        public Library(Dictionary<Book, BookStatus> books)
        {
            Books = books;
        }

        public Guid AddBook(Book book)
        {
            var bookToAdd = GetBook(book.Title);
            if (string.IsNullOrEmpty(bookToAdd.Title?.Trim()))
            {
                Books.Add(book, BookStatus.Available);
                return book.ISBN;
            }
            throw new AlreadyExistsException("Book with this title already Exists");
        }

        public Dictionary<Book, BookStatus> GetAllBooks()
        {
            return Books;
        }

        public string RemoveBook(string Title)
        {
            var book = GetBook(Title);
            if (!string.IsNullOrEmpty(book.Title?.Trim()))
            {
                Books.Remove(book);
                return book.Title;
            }
            throw new NotFoundException("Book with this title is not Found");
        }
        public Book GetBook(string Title)
        {
            var bookInLibrary = Books.FirstOrDefault(x => x.Key.Title == Title).Key;
            return bookInLibrary != null ? bookInLibrary : null;
        }

    }
}
