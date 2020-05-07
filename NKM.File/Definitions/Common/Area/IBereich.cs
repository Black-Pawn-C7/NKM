using NKM.File.Definitions.Common.Dienst;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Definitions.Common.Area {
    public interface IBereich {
        int BereichID { get; set; }
        string BereichName { get; set; }

        IMemberShort BV { get; set; }
        IAbrechnung Abrechnung { get; set; }

        bool ListPrinted { get; set; }
    }
}