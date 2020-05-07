using NKM.File.Common;

namespace NKM.File.Definitions.Common.Person {
    public interface IUser : IMemberShort {
        int LoginID { get; set; }
        string UserName { get; set; }

        byte[] Salt { get; set; }
        byte[] Hash { get; set; }

        Rights Rechte { get; }

        bool PasswordIsExpired();
        bool PasswordWillExpireInThreeDays();
    }
}