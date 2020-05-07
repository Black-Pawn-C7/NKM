using NKM.File.Common.Person;

namespace NKM.File.Common {
    public static class Converter {
        public static AV User_To_AV(User value) {
            return new AV {
                UserName = value.UserName,
                LoginID = value.LoginID,
                MemberID = value.MemberID,
                Nachname = value.Nachname,
                Spitzname = value.Spitzname,
                Vorname = value.Vorname
            };
        }
    }
}