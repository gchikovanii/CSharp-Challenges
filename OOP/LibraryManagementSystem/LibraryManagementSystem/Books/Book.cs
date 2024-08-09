using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Books
{
    public class Book 
    {
        public Book(string title, string author, Guid iSBN, string publisher, string publishedDate, Genre genre)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            PublishedDate = publishedDate;
            Genre = genre;
        }
        public Book()
        {
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public Guid ISBN { get; private set; }
        public string Publisher { get; private set; }
        public string PublishedDate { get; private set; }
        public Genre Genre { get; private set; }

    }
}
