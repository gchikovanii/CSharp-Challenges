using LibraryManagementSystem.Books;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Exceptions;
using LibraryManagementSystem.Libraries;
using LibraryManagementSystem.Loans;
using LibraryManagementSystem;

List<Book> books = new List<Book>()
        {
            new Book("Power of One More", "Ed Mylet", Guid.NewGuid(), "Lurji Okeane", "2019", Genre.Fiction, Condition.Excellent),
            new Book("12 Rules of Life", "Jordan Peterson", Guid.NewGuid(), "Lurji Okeane", "2020", Genre.Science, Condition.Good),
            new Book("The Art of Body Language", "Alan and Barbara Pease", Guid.NewGuid(), "Lurji Okeane", "2022", Genre.Fantasy, Condition.Bad)
        };

// Initialize the library and add books
List<Book> newBooks = new List<Book>();
Library library = new Library(newBooks);
foreach (var book in books)
{
    try
    {
        library.AddBook(book);
        Console.WriteLine($"Added: {book.Title}");
    }
    catch (AlreadyExistsException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Display all books in the library
Console.WriteLine("\nAll Books in Library:");
foreach (var book in library.GetAllBooks())
{
    book.Information();
    Console.WriteLine();
}

// Declare a member
Member member = new Member(Guid.NewGuid(), "Giorgi", "gchiova@gmail.com", "574093134", new List<Book>());

// Borrow a book
ILoan loan = new Loan();
try
{
    loan.BorrowBook(books[0], member);
    Console.WriteLine($"\n{member.Email} has borrowed {books[0].Title}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Display borrowed books for the member
Console.WriteLine("\nBooks Borrowed by Member:");
foreach (var borrowedBook in member.BooksBorrowed)
{
    borrowedBook.Information();
    Console.WriteLine();
}

// Return a book
try
{
    loan.ReturnBook(books[0], member);
    Console.WriteLine($"\n{member.Email} has returned {books[0].Title}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Attempt to remove a book from the library
try
{
    string removedBookTitle = library.RemoveBook("12 Rules of Life");
    Console.WriteLine($"\nRemoved book: {removedBookTitle}");
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

// Display remaining books in the library
Console.WriteLine("\nRemaining Books in Library:");
foreach (var book in library.GetAllBooks())
{
    book.Information();
    Console.WriteLine();
}
