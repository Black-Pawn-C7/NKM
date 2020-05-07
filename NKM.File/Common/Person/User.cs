using System;
using System.Xml.Serialization;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Common.Person {
    [Serializable]
    public class User : IUser {
        [XmlIgnore] public DateTime PasswordWasChangedOn { get; set; }

        [XmlIgnore] public DateTime PasswordWillExpiresOn { get; set; }

        /// <summary>
        ///     Die Mitglieder ID
        /// </summary>
        public int MemberID { get; set; }

        public int LoginID { get; set; }

        public string UserName { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        [XmlIgnore] public string Spitzname { get; set; }

        [XmlIgnore] public byte[] Salt { get; set; }

        [XmlIgnore] public byte[] Hash { get; set; }

        [XmlIgnore] public Rights Rechte { get; set; }

        public bool PasswordIsExpired() {
            var result = (PasswordWillExpiresOn - DateTime.UtcNow).TotalDays;
            return result <= 0;
        }

        public bool PasswordWillExpireInThreeDays() {
            var result = (PasswordWillExpiresOn - DateTime.UtcNow).TotalDays;
            return result > 0 && result < 3;
        }

        public string FullName() {
            return $"{Vorname.Trim(' ')} {Nachname.Trim(' ')}";
        }
    }
}