namespace Proxy
{

    public interface IDocument
    {
        void DisplayDocument();
    }
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccesed { get; private set; }
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing heavy action, loading data...");
            Thread.Sleep(2000);
            Title = "Test Title N1";
            Content = "Test Content N1";
            AuthorId = 1;
            LastAccesed = DateTimeOffset.UtcNow;

        }
        public void DisplayDocument()
        {
            Console.WriteLine($"{Title} - {Content}");
        }
    }

    public class DocumentProxy : IDocument
    {
        private string _fileName;
        private Lazy<Document> _document;
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }

    }
}
