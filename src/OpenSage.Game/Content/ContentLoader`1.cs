using OpenSage.Data;

namespace OpenSage.Content
{
    public abstract class ContentLoader<T> : ContentLoader
    {
        public sealed override object Load(IFileSystemEntry entry, ContentManager contentManager, LoadOptions loadOptions)
        {
            return LoadEntry(entry, contentManager, loadOptions);
        }

        protected abstract T LoadEntry(IFileSystemEntry entry, ContentManager contentManager, LoadOptions loadOptions);
    }
}
