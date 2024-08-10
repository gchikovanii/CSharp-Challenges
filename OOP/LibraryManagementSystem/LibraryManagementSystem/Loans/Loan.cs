using LibraryManagementSystem.Books;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Exceptions;

namespace LibraryManagementSystem.Loans
{
    public class Loan : ILoan
    {
        private List<Loan>? loans = new List<Loan>();   
        public Guid LoanId { get; private set; }
        public Book Book { get; private set; }
        public Member Member { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        private Loan(Guid loanId, Book book, Member member, DateTime loanDate, DateTime dueDate)
        {
            LoanId = loanId;
            Book = book;
            Member = member;
            LoanDate = loanDate;
            DueDate = dueDate;
        }
        public Loan()
        {
            
        }
        public void BorrowBook(Book book, Member member)
        {
            if (book == null || member == null)
                throw new ArgumentNullException("Book and Member cannot be null");
            if (member.BooksBorrowed.Count >= 3)
                throw new BookLimitException("You can borrow only 3 books, please return at least one if you want to loan out new book");
            if(loans != null)
            {
                if (loans.Any(i => i.Book.Title == book.Title))
                    throw new BookAlreadyLoaned("Book is not avaliable");
            }
            if (member.BooksBorrowed.Find(i => i.Title == book.Title) != null)
                throw new AlreadyBorrowedException("You already have this book");
            loans.Add(new Loan(Guid.NewGuid(),book,member,DateTime.Now,DateTime.Now.AddDays(30)));   
            member.BooksBorrowed.Add(book);
        }
        public void ReturnBook(Book book, Member member)
        {
            if(book == null || member == null)
                throw new ArgumentNullException("Book and Member cannot be null");
            var loan = loans.FirstOrDefault(i => i.Book.Title == book.Title && i.Member.Email == member.Email);
            if (loan == null)
                throw new LoanInformationMissmatchException("You have not borrowed this book");
            if (DateTime.Now >= loan.DueDate)
                throw new PenaltyExeption("You must come to adimistration and pay penalty for returning book not in time");
           loans.Remove(loan);
        }
    }
}
