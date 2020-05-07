using StukInformationSystem.Data.Definitions.Common.Models;
using System;

namespace StukInformationSystem.Data.Common.Models {
    [Serializable]
    public class Mitgliedsbeitrag : IMitgliedsbeitrag {
        public int ID { get; set; }
        public int MemberStatus { get; set; }
        public double DienstSoll { get; set; }
        public double AeSoll { get; set; }
        public double SchulungSoll { get; set; }
        public int AutoStatus { get; set; }
        public string Bemerkung { get; set; }
        public bool Inaktiv { get; set; }
        public int Bearbeiter { get; set; }
        public int Ersteller { get; set; }
        public DateTime Stand { get; set; }
    }
}
