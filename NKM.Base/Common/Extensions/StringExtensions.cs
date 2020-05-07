using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKM.Base.Common.Extensions {
   public static class StringExtensions {
        public static byte[] ToByteArray(this string value) {
            UnicodeEncoding enc = new UnicodeEncoding();
            return enc.GetBytes(value);
        }
    }
}
