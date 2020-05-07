using System;
using NKM.File.Definitions.Common.Area;
using NKM.File.Definitions.Common.Dienst;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Common.Area {
    [Serializable]
    public class Bereich : IBereich {
        public int BereichID { get; set; }
        public string BereichName { get; set; }
        public IMemberShort BV { get; set; }
        public IAbrechnung Abrechnung { get; set; }
        public bool ListPrinted { get; set; }
    }
}