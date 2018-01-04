using System;
using OpenSage.Data;

namespace OpenSage.DataViewer.Framework
{
    public sealed class FileSystemEntryEventArgs : EventArgs
    {
        public IFileSystemEntry Entry { get; }

        public FileSystemEntryEventArgs(IFileSystemEntry entry)
        {
            Entry = entry;
        }
    }
}
