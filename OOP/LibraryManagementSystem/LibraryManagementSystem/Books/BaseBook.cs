using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Books
{
    public class BaseBook
    {
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public Guid ISBN { get; protected set; }
        public string Publisher { get; protected set; }
        public string PublishedDate { get; protected set; }
        public Genre Genre { get; protected set; }
        public BaseBook(string title, string author, Guid iSBN, string publisher, string publishedDate, Genre genre)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            PublishedDate = publishedDate;
            Genre = genre;
        }
        public virtual void Information()
        {
            Console.WriteLine("Book Title: {0} - Genre: {1} - Author: {2} - Publisher: {3}",Title,Genre.ToString(),Author,Publisher);
        }
    }
}
