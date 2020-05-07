using System;

namespace NKM.File.Definitions.Common.Dienst {
    public interface ILocalDienste {
        int MID { get; set; }
        int Aufgabe { get; set; }
        DateTime Beginn { get; set; }
        DateTime Ende { get; set; }
        double Multi { get; set; }
        double Gutscheine { get; set; }
        bool Putzen { get; set; }
        string Bemerkung { get; set; }
    }
}
