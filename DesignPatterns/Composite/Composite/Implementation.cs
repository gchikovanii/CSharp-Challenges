using System.ComponentModel;

namespace Composite
{
    public class Implementation
    {
        public abstract class FileSystemItem
        {
            public string Name { get; set; }

            protected FileSystemItem(string name)
            {
                Name = name;
            }

            public abstract long GetSize();
        }

        public class CustomFile : FileSystemItem
        {
            private long _size;
            public CustomFile(string name, long size) : base(name)
            {
                _size = size;
            }
            public override long GetSize()
            {
                return _size;
            }
        }
        public class CustomDirectory : FileSystemItem
        {
            private long _size;
            private List<FileSystemItem> _fileSystemItems = new List<FileSystemItem>();
            public CustomDirectory(string name, long size) : base(name)
            {
                _size = size;
            }
            public void AddFileItem(FileSystemItem fileSystemItem)
            {
                _fileSystemItems.Add(fileSystemItem);   
            }
            public void DeleteFileItem(FileSystemItem fileSystemItem)
            {
                _fileSystemItems.Remove(fileSystemItem);
            }
            public override long GetSize()
            {
                var treeSize = _size;
                foreach (var item in _fileSystemItems)
                {
                    treeSize += item.GetSize();
                }
                return treeSize;
            }
        }
    }
}
