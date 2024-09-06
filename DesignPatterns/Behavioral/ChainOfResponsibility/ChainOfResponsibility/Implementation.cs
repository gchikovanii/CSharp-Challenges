using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility
{
    public class Document
    {
        public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagement = approvedByManagement;
        }

        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagement { get; set; }
    }

    public interface IHandler<T> where T : class
    {
        IHandler<T> SetSuccessor(IHandler<T> handler);
        void Handle(T request);
    }

    public class DocumentTitleHandler : IHandler<Document>
    {
        private IHandler<Document>? _succesor;
        public void Handle(Document document)
        {
            if(document.Title == string.Empty)
                throw new ValidationException(new ValidationResult("Title cant be empty",new List<string>() { "Title"}), null,null);
            _succesor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _succesor = successor;
            return _succesor;
        }
    }

    public class DocumentLastModifiedHandler : IHandler<Document>
    {
        private IHandler<Document>? _succesor;
        public void Handle(Document document)
        {
            if (document.LastModified< DateTimeOffset.UtcNow.AddDays(-15))
                throw new ValidationException(new ValidationResult("Edited 15 days checker", new List<string>() { "Title" }), null, null);
            _succesor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _succesor = successor;
            return _succesor;
        }
    }
    public class DocumentapprovedbyLitigationHandler : IHandler<Document>
    {
        private IHandler<Document>? _succesor;
        public void Handle(Document document)
        {
            if (document.ApprovedByLitigation)
                throw new ValidationException(new ValidationResult("Dont approved by Litigation", new List<string>() { "Title" }), null, null);
            _succesor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _succesor = successor;
            return _succesor;
        }
    }
    public class DocumentapprovedbyManagementHandler : IHandler<Document>
    {
        private IHandler<Document>? _succesor;
        public void Handle(Document document)
        {
            if (document.ApprovedByLitigation)
                throw new ValidationException(new ValidationResult("Dont approved by Management", new List<string>() { "Title" }), null, null);
            _succesor?.Handle(document);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _succesor = successor;
            return _succesor;
        }
    }
}
