namespace NKM.File.Definitions.Common.Person {
    public interface IUserAdditions {
        int UserID { get; set; }
        byte[] UserImage { get; set; }
        byte[] UserSettings { get; set; }
        byte[] UserMessages { get; set; }
    }
}
