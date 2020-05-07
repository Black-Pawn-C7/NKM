using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NKM.Base.Common.Extensions {
    public static class CommonExtensions {
        public static byte[] ToArray(this Image image) {
            using (var ms = new MemoryStream()) {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        public static Image Resize250(this Image image) {
            var sz = new Size(250, 250);
            return HelperClass.ResizeIntern(image, sz);
        }
        public static Image Resize120(this Image image) {
            var sz = new Size(120, 120);
            return HelperClass.ResizeIntern(image, sz);
        }

    }
}
