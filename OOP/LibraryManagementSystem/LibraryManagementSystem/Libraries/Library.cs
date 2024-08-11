using LibraryManagementSystem.Books;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Exceptions;
namespace LibraryManagementSystem.Libraries
{
    public class Library 
    {
        //Has A relatioship
        private readonly List<Book> Books;

        public Library(List<Book> booksList)
        {
            Books = booksList;
        }

        public Guid AddBook(Book book)
        {
            var bookToAdd = GetBook(book.Title);
            if (bookToAdd == null)
            {
                Books.Add(book);
                return book.ISBN;
            }
            throw new AlreadyExistsException("Book with this title already Exists");
        }

        public List<Book> GetAllBooks()
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
            var bookInLibrary = Books.FirstOrDefault(x => x.Title == Title);
            return bookInLibrary != null ? bookInLibrary : null;
        }

    }
}
