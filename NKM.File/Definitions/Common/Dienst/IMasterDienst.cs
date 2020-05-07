using NKM.Base.Definition.Enums;
using NKM.File.Definitions.Common.Person;
using System;

namespace NKM.File.Definitions.Common.Dienst {
    public interface IMasterDienst {
        int DienstID { get; }
        DateTime Beginn { get; set; }
        DateTime Ende { get; set; }
        int AV { get; set; }
        bool Abgeschlossen { get; set; }
        IMemberShort BV { get; set; }
        ItemRowState ItemState { get; set; }
        IMasterDienst OrginalRowState { get; set; }
        int Gaeste { get; set; }
    }
}