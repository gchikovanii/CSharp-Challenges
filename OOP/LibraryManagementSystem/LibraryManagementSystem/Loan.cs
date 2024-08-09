using LibraryManagementSystem.Books;

namespace LibraryManagementSystem
{
    public class Loan : ILoan
    {
        public Guid LoanId { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
