using LibraryManagementSystem.Books;

namespace LibraryManagementSystem.Loans
{
    public interface ILoan
    {
        void BorrowBook(Book book, Member member);
        void ReturnBook(Book book, Member member);
    }
}
