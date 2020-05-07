using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKM.Base.Common.Extensions {
    public static class ByteExtensions {
        public static string ToUnicodeString(this byte[] value) {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            return unicodeEncoding.GetString(value);
        }
    }
}
