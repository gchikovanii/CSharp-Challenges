using LibraryManagementSystem.Books;

namespace LibraryManagementSystem
{
    public class Member
    {
        public Member(Guid memberId, string name, string email, string phone,  List<Book> booksBorrowed)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            Phone = phone;
            BooksBorrowed = booksBorrowed;
        }
        private Guid MemberId;
        private string Name;
        public string Email;
        private string Phone;
        public List<Book> BooksBorrowed;
    }
}
