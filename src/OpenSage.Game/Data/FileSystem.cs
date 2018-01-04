using System;
using System.Collections.Generic;
using System.IO;
using OpenSage.Data.Big;

namespace OpenSage.Data
{
    public interface IFileSystem : IDisposable
    {
        string RootDirectory { get; }
        IReadOnlyCollection<IFileSystemEntry> Files { get; }
        IFileSystemEntry GetFile(string filePath);
        IFileSystemEntry SearchFile(string fileName, params string[] searchFolders);
        IEnumerable<IFileSystemEntry> GetFiles(string folderPath);

        IFileSystem NextFileSystem { get; }
    }

    public sealed class BigFileSystem : IFileSystem
    {
        private readonly Dictionary<string, BigFileSystemEntry> _fileTable;
        private readonly List<BigArchive> _bigArchives;

        public string RootDirectory { get; }

        public IFileSystem NextFileSystem { get; }

        public IReadOnlyCollection<IFileSystemEntry> Files => _fileTable.Values;

        public BigFileSystem(string rootDirectory, IFileSystem nextFileSystem = null)
        {
            RootDirectory = rootDirectory;

            NextFileSystem = nextFileSystem;

            _fileTable = new Dictionary<string, BigFileSystemEntry>(StringComparer.OrdinalIgnoreCase);
            _bigArchives = new List<BigArchive>();

            // TODO: Figure out if there's a specific order that .big files should be loaded in,
            // since some files are contained in more than one .big file so the later one
            // takes precedence over the earlier one.

            foreach (var file in Directory.GetFiles(rootDirectory, "*.*", SearchOption.AllDirectories))
            {
                var ext = Path.GetExtension(file).ToLower();
                if (ext == ".big")
                {
                    var bigStream = File.OpenRead(file);
                    var archive = new BigArchive(bigStream);

                    _bigArchives.Add(archive);

                    foreach (var entry in archive.Entries)
                    {
                        _fileTable[entry.FullName] = new BigFileSystemEntry(this, entry.FullName, entry.Length, entry.Open);
                    }
                }
                else
                {
                    var relativePath = file.Substring(rootDirectory.Length);
                    if (relativePath.StartsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        relativePath = relativePath.Substring(1);
                    }
                    _fileTable[relativePath] = new BigFileSystemEntry(this, relativePath, (uint) new FileInfo(file).Length, () => File.OpenRead(file));
                }
            }
        }

        public IFileSystemEntry GetFile(string filePath)
        {
            if (_fileTable.TryGetValue(filePath, out var file))
            {
                return file;
            }

            return NextFileSystem?.GetFile(filePath);
        }

        public IFileSystemEntry SearchFile(string fileName, params string[] searchFolders)
        {
            foreach (var searchFolder in searchFolders)
            {
                if (_fileTable.TryGetValue(Path.Combine(searchFolder, fileName), out var file))
                {
                    return file;
                }
            }

            return NextFileSystem?.SearchFile(fileName, searchFolders);
        }

        public IEnumerable<IFileSystemEntry> GetFiles(string folderPath)
        {
            foreach (var entry in _fileTable.Values)
            {
                if (entry.FilePath.StartsWith(folderPath))
                {
                    yield return entry;
                }
            }

            if (NextFileSystem != null)
            {
                foreach (var entry in NextFileSystem.GetFiles(folderPath))
                {
                    yield return entry;
                }
            }
        }

        public void Dispose()
        {
            foreach (var archive in _bigArchives)
                archive.Dispose();
            _bigArchives.Clear();
        }
    }
}
