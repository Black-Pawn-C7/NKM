using System;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Common.Person {
    [Serializable]
    public abstract class BaseMember : IMemberShort {
        public int MemberID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Spitzname { get; set; }

        public string FullName() {
            return $"{Vorname.Trim(' ')} {Nachname.Trim(' ')}";
        }
    }
}