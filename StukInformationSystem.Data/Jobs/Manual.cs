using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.File.Definitions.Common.Person;

namespace StukInformationSystem.Data.Jobs
{
    public static class Manual
    {
        public static IResult GutscheinTransfer(MemberGutscheinTransfer value)
        {
            return new FailureResult();
        }
    }



}
public class MemberGutscheinTransfer : IMemberShort
{
    public int MemberID { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Spitzname { get; set; }

    public double Gutscheine { get; set; }

    public int Empfänger { get; set; }

    public string FullName() =>  $"{Vorname} {Nachname}";



}
