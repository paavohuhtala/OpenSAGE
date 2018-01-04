using System;
using System.IO;

namespace OpenSage.Data
{
    public sealed class FileSystemEntry
    {
        private readonly Func<Stream> _open;

        public IFileSystem FileSystem { get; }
        public string FilePath { get; }
        public uint Length { get; }

        public FileSystemEntry(IFileSystem fileSystem, string filePath, uint length, Func<Stream> open)
        {
            FileSystem = fileSystem;
            FilePath = filePath;
            Length = length;
            _open = open;
        }

        public Stream Open() => _open();
    }
}
