using LibraryManagementSystem.Books;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace LibraryManagementSystem
{
    public class Member
    {
        public Member(Guid memberId, string name, string email, string phone, string membershipDate, List<Book> booksBorrowed, IBook book)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            Phone = phone;
            MembershipDate = membershipDate;
            BooksBorrowed = booksBorrowed;
            _book = book;
        }
        private readonly IBook _book;
        private Guid MemberId;
        private string Name;
        private string Email;
        private string Phone;
        private string MembershipDate;
        private List<Book> BooksBorrowed;
    
        
        public bool BorrowBook(string title)
        {
            
        }


    }
}
//Task: Design and Implement a Library Management System
//Requirements:
//Core Classes and Relationships:

//Book: Represents a book in the library. It should have attributes like Title, Author, ISBN, Publisher, PublishedDate, and Genre.
//Member: Represents a library member. Attributes should include MemberID, Name, Email, Phone, MembershipDate, and BooksBorrowed.
//Library: Manages the collection of books and members. It should be able to add or remove books and members, and track which books are borrowed by which members.
//Loan: Represents a loan when a member borrows a book. Attributes include LoanID, Book, Member, LoanDate, and DueDate.
//Functional Requirements:

//Book Borrowing: A member should be able to borrow a book if it is available. This should create a Loan object and update the BooksBorrowed count for the member.
//Book Returning: A member should be able to return a borrowed book. This should remove the corresponding Loan and update the book's availability.
//Search Functionality: Implement search functions in the Library class to find books by Title, Author, or Genre.
//Overdue Books: The system should be able to identify books that are overdue and generate a report.
//Additional Features:

//Extend Loan: A member should be able to extend the loan period for a book if it’s not overdue and no other member has requested it.
//Membership Types: Implement different types of memberships (e.g., Regular, Premium) that might have different borrowing limits and privileges.
//Reservation System: Allow members to reserve books that are currently borrowed by others. When the book is returned, the first member in the reservation list should be notified.
//Design Considerations:

//Use proper encapsulation to hide data.
//Implement inheritance where appropriate (e.g., if you decide to extend the Book class for different types of books like Ebook or AudioBook).
//Utilize polymorphism, for example, by allowing different types of members (Regular, Premium) to borrow books with different rules.
//Apply principles like SOLID to ensure that your classes are well-structured, maintainable, and scalable.
//Documentation:

//Document your design choices, explaining why you structured your classes and methods the way you did.
//Provide a class diagram to visually represent the relationships between classes.
//Write unit tests to ensure the correctness of your code, especially focusing on edge cases (e.g., attempting to borrow a book that’s already borrowed).