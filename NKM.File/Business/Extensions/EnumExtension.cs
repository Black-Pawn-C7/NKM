using System;

namespace NKM.File.Business.Extensions {
    public static class EnumExtension {
        public static bool TryStringToEnum<TEnum>(this string enumValue, out TEnum enumeration) where TEnum : struct {
            var result = Enum.TryParse(enumValue, out TEnum eEnum);

            enumeration = eEnum;

            return result;
        }
    }
}