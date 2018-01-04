using Eto.Drawing;
using Eto.Forms;
using OpenSage.Data;

namespace OpenSage.DataViewer.UI.Viewers
{
    public sealed class BmpView : ImageView
    {
        public BmpView(IFileSystemEntry entry)
        {
            using (var stream = entry.Open())
            {
                Image = new Bitmap(stream);
            }
        }
    }
}
