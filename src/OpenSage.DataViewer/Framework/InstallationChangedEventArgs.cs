using System;
using OpenSage.Data;

namespace OpenSage.DataViewer.Framework
{
    public sealed class InstallationChangedEventArgs : EventArgs
    {
        public GameInstallation Installation { get; }
        public IFileSystem FileSystem { get; }

        public InstallationChangedEventArgs(GameInstallation installation, IFileSystem fileSystem)
        {
            Installation = installation;
            FileSystem = fileSystem;
        }
    }
}
