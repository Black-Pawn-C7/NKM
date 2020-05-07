using System;
using NKM.File.Common.Person;
using NKM.File.Definitions.Common.Dienst;

namespace NKM.File.Common.Area {
    [Serializable]
    public class Abrechnung : IAbrechnung {
        public int Id { get; set; }
        public BaseMember Member { get; set; }
        public double Wechselgeld { get; set; }
        public double BargeldInKasse { get; set; }
        public double BargeldNachDienst { get; set; }
        public double EinnahmeBargeld { get; set; }
        public double Belege { get; set; }
        public double WechselgeldKasse { get; set; }
        public double Gesamt { get; set; }
        public bool Gedruckt { get; set; }
    }
}