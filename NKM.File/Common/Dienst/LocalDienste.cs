using System;
using NKM.File.Definitions.Common.Dienst;

namespace NKM.File.Common.Dienst {
    [Serializable]
    public class LocalDienste : ILocalDienste {
        public int MID { get; set; }
        public int Aufgabe { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public double Multi { get; set; }
        public bool Putzen { get; set; }
        public double Gutscheine { get; set; }
        public string Bemerkung { get; set; }

    }
}
