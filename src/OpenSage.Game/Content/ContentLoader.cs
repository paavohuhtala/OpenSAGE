using System.Collections.Generic;
using OpenSage.LowLevel.Graphics3D;
using OpenSage.Data;

namespace OpenSage.Content
{
    public abstract class ContentLoader : GraphicsObject
    {
        public virtual object PlaceholderValue => null;

        public virtual IEnumerable<string> GetPossibleFilePaths(string filePath)
        {
            yield return filePath;
        }

        public abstract object Load(IFileSystemEntry entry, ContentManager contentManager, LoadOptions loadOptions);
    }
}
