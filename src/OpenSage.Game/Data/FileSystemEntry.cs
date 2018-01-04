using System;
using System.IO;

namespace OpenSage.Data
{
    public interface IFileSystemEntry
    {
        string FilePath { get; }
        uint Length { get; }
        IFileSystem FileSystem { get; }
        Stream Open();
    }

    public sealed class BigFileSystemEntry : IFileSystemEntry
    {
        private readonly Func<Stream> _open;

        public IFileSystem FileSystem { get; }
        public string FilePath { get; }
        public uint Length { get; }

        public BigFileSystemEntry(IFileSystem fileSystem, string filePath, uint length, Func<Stream> open)
        {
            FileSystem = fileSystem;
            FilePath = filePath;
            Length = length;
            _open = open;
        }

        public Stream Open() => _open();
    }
}
