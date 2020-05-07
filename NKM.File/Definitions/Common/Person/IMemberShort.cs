namespace NKM.File.Definitions.Common.Person {
    public interface IMemberShort {
        int MemberID { get; set; }

        string Vorname { get; set; }
        string Nachname { get; set; }
        string Spitzname { get; set; }

        string FullName();
    }
}