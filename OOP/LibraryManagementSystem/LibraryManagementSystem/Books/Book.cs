using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Books
{
    public sealed class Book : BaseBook
    {
        public Condition Condition { get; private set; }
        public Book(string title, string author, Guid iSBN, string publisher, string publishedDate, Genre genre, Condition condition
            ) : base(title, author, iSBN, publisher, publishedDate, genre)
        {
            Condition = condition;
        }

        public override void Information()
        {
            base.Information();
            Console.Write(" Condition - {0}",Condition.ToString());
        }
    }
}
