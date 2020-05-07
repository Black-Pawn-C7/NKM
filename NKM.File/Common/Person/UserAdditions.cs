using NKM.File.Definitions.Common.Person;
namespace NKM.File.Common.Person {
    public class UserAdditions : IUserAdditions {
        public int UserID { get; set; }
        public byte[] UserImage { get; set; }
        public byte[] UserSettings { get; set; }
        public byte[] UserMessages { get; set; }
    }
}
