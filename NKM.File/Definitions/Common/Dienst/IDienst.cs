using System;
using System.Collections.Generic;
using NKM.File.Common.Person;
using NKM.File.Definitions.Common.Area;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Definitions.Common.Dienst {
    public interface IDienst {
        Guid ID { get; }
        int DienstID { get; }
        string VeranstaltungName { get; set; }

        AV AV { get; set; }
        IMemberShort ProbeAV { get; set; }
        DateTime DayOfAbend { get; set; }
        IList<ILocalDienste> Dienste { get; set; }
        byte[] BarVerbrauch { get; set; }
        byte[] GutscheinVerbrauch { get; set; }
        string ProgramVersion { get; set; }

        IList<IBereich> Bereiche { get; set; }

        bool PrivatParty { get; set; }
        bool IsDienstag();
    }
}